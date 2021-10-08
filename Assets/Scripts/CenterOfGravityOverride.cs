using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CenterOfGravityOverride : MonoBehaviour
{
    public Transform centerOfGravity;
    public bool comEnabled;

    private void Awake()
    {
        if (comEnabled)
            GetComponent<Rigidbody>().centerOfMass = centerOfGravity.localPosition;
    }

}
