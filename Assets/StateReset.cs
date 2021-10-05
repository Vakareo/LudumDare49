using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StateReset : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 initialRotation;
    private Rigidbody rb;
    private void Awake()
    {
        initialPosition = transform.position;
        initialRotation = transform.eulerAngles;
        rb = GetComponent<Rigidbody>();
    }

    public void Reset()
    {
        transform.position = initialPosition;
        transform.eulerAngles = initialRotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
