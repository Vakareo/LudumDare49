using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float speed;
    public float changeRate;
    private Vector3 direction;

    public WaitForSeconds wait;

    private void OnValidate()
    {
        wait = new WaitForSeconds(1f / changeRate);
    }

    private void Awake()
    {
        StartCoroutine(ChangeDirection());
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            direction = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
            yield return wait;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += direction * speed * Time.deltaTime;
    }
}
