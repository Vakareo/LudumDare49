using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour, IInputUpdate
{
    public float ackerman = 1.25f;
    public float maxAngle = 35;
    public Transform rightWheel;
    public Transform leftWheel;
    private float currentAngle;
    private MyInputsObject input;

    private void Awake()
    {
        input = FindObjectOfType<MyInputsObject>();
    }
    public void InputUpdate()
    {
        var steer = input.myInputs.Base.Horizontal.ReadValue<float>();
        currentAngle = steer * maxAngle;
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
