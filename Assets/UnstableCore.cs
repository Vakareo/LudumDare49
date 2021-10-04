using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableCore : MonoBehaviour
{
    [Range(0.2f, 4f)]
    public float falloff = 1f;
    [Range(0, 2000)]
    public float maxRange = 200f;
    private UnstableItem[] items;
    private Player[] players;


    private void Start()
    {
        items = FindObjectsOfType<UnstableItem>();
        players = FindObjectsOfType<Player>();
    }

    private void Update()
    {
        for (int i = 0; i < items.Length; i++)
        {
            var distance = GetDistance(items[i].transform.position);
            if (distance <= maxRange)
            {
                var value = Mathf.Pow(distance / maxRange, falloff);
                items[i].ApplyInstability(value);
            }
            else
            {
                items[i].ApplyInstability(1f);
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

    private float GetDistance(Vector3 position)
    {
        return (transform.position - position).magnitude;
    }

}
