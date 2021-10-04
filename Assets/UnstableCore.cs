using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableCore : MonoBehaviour
{
    [Range(0.2f, 4f)]
    public float falloff = 1f;
    [Range(0, 2000)]
    public float maxRange = 200f;
    public float UpdateRate = 0.5f;
    private UnstableItem[] unstables;
    private Player[] players;


    private WaitForSeconds wait;

    private void OnValidate()
    {
        wait = new WaitForSeconds(1f / UpdateRate);
    }


    private void Start()
    {
        unstables = FindObjectsOfType<UnstableItem>();
        players = FindObjectsOfType<Player>();
        StartCoroutine(UpdateDirection());
    }

    IEnumerator UpdateDirection()
    {
        while (true)
        {
            UpdateDirectionsOnObjects();
            yield return wait;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        for (int i = 0; i < unstables.Length; i++)
        {
            var distance = GetDistance(unstables[i].transform.position);
            if (distance <= maxRange)
            {
                var value = Mathf.Pow(distance / maxRange, falloff);
                unstables[i].ApplyInstability(value);
            }
            else
            {
                unstables[i].ApplyInstability(1f);
            }
        }
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < players.Length; i++)
        {
            var player = players[i];
            var distance = GetDistance(player.transform.position);
            if (distance <= maxRange)
            {
                var value = Mathf.Pow(distance / maxRange, falloff);
                player.ApplyInstability(value);
            }
            else
            {
                player.ApplyInstability(1f);
            }
        }

    }
    private void UpdateDirectionsOnObjects()
    {
        for (int i = 0; i < unstables.Length; i++)
        {
            unstables[i].UpdateDirection();
        }
    }

    private float GetDistance(Vector3 position)
    {
        return (transform.position - position).magnitude;
    }

}
