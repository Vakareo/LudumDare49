using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour, IInputUpdate
{
    public float ackerman = 1.25f;
    public float maxAngle = 35;
    public Transform rightWheel;
    public Transform leftWheel;
    public float steerPower = 1f;
    public float turnRate = 90f;
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
        steer = Mathf.Sign(steer) * Mathf.Pow(Mathf.Abs(steer), steerPower);
    }

    public void UpdateSteering()
    {
        currentAngle = steer * maxAngle; //* turnRate * Time.deltaTime;
        if (steer == 0 && currentAngle != 0)
        {
            var oldSign = Mathf.Sign(currentAngle);
            currentAngle = -oldSign * maxAngle * turnRate * Time.deltaTime;
            if (Mathf.Sign(currentAngle) != oldSign)
            {
                currentAngle = 0;
            }
        }
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
