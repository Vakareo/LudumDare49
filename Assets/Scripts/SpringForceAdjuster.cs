using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringForceAdjuster : MonoBehaviour
{
    public float force = 500f;
    public float damper = 0.2f;
    private SpringJoint[] joints;
    private void OnValidate()
    {
        SetValues();
    }
    private void Awake()
    {
        SetValues();
    }

    private void SetValues()
    {
        joints = GetComponents<SpringJoint>();
        for (int i = 0; i < joints.Length; i++)
        {
            joints[i].spring = force;
            joints[i].damper = damper;
        }
    }
}
