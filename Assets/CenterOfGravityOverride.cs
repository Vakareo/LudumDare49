using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CenterOfGravityOverride : MonoBehaviour
{
    public Transform centerOfGravity;
    public bool enabled;

    private void Awake()
    {
        if (enabled)
            GetComponent<Rigidbody>().centerOfMass = centerOfGravity.position;
    }

}
