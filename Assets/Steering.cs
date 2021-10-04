using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour, IInputUpdate
{
    public float ackerman = 1.25f;
    public float maxAngle = 35;
    public Transform rightWheel;
    public Transform leftWheel;

    public bool hasSpeedLimit = false;
    public float speedLimit = 8f;
    private Rigidbody rb;
    private float currentAngle;
    private MyInputsObject input;
    private float steer;
    public float falloff;

    private void Awake()
    {
        input = FindObjectOfType<MyInputsObject>();
        rb = GetComponentInParent<Rigidbody>();
    }
    public void InputUpdate()
    {
        steer = input.myInputs.Base.Horizontal.ReadValue<float>();
    }

    public void UpdateSteering()
    {
        currentAngle = steer * maxAngle;
        if (hasSpeedLimit)
        {
            var speed = Vector3.Dot(rb.velocity, rb.transform.forward);
            var value = Mathf.Clamp01(speed / speedLimit);
            currentAngle *= Mathf.Pow((1 - value), falloff);
        }

        var rightValue = 0f;
        var leftValue = 0f;

        if (currentAngle < 0)
        {
            rightValue = currentAngle;
            leftValue = currentAngle * ackerman;
        }
        else
        {
            leftValue = currentAngle;
            rightValue = currentAngle * ackerman;
        }

        rightWheel.localEulerAngles = new Vector3(rightWheel.localEulerAngles.x, rightValue, rightWheel.localEulerAngles.z);
        leftWheel.localEulerAngles = new Vector3(leftWheel.localEulerAngles.x, leftValue, leftWheel.localEulerAngles.z);
    }
}
