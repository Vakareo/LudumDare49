using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RandomForce : MonoBehaviour
{
    private Rigidbody rb;
    public float force;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        var rand = Random.Range(0, 41);
        if (rand == 10)
        {
            rb.AddForce(force * transform.forward);
        }
    }
}
