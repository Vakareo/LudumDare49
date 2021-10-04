using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpringAndDamper))]
public class TireForce : MonoBehaviour, ITire, IInputUpdate
{
    public float maxOverspin = 2f;
    private MyInputsObject inputs;
    private SpringAndDamper spring;
    public bool ABS = true;
    public bool isLeft;
    private Rigidbody rb;
    public TireData tire;
    public bool normalize = true;
    public float motorPower;
    public float brakeForce;
    public float brakeFactor;
    public float motorFactor;
    public float minVel = 0.001f;
    public bool test;
    public float radsPerSecond;
    private float forwardSlip;
    public float LateralSlip { get; private set; }
    private float forwardVel;
    private float lateralVel;
    private float forwardForce;
    private float lateralForce;
    private float rollingTorque;
    private float throttle;
    private float brake;

    private void Awake()
    {
        rb = transform.root.GetComponent<Rigidbody>();
        spring = GetComponent<SpringAndDamper>();

    }
    private void Start()
    {
        inputs = FindObjectOfType<MyInputsObject>();
    }
    public void InputUpdate()
    {
        throttle = inputs.myInputs.Base.Throttle.ReadValue<float>();
        brake = inputs.myInputs.Base.Brake.ReadValue<float>();
    }

    private float GetRollingTorque(float forwardForce, float inertia)
    {
        var accel = (-forwardForce) / (tire.mass * tire.radius);
        var myTorque = inertia * accel;
        return myTorque;
    }


    public void PhysicsUpdate()
    {
        var inertia = tire.mass * 0.5f * Mathf.Pow(tire.radius, 2);
        radsPerSecond += motorPower * Mathf.Pow(throttle, motorFactor) / inertia * Time.deltaTime;
        var oldSign = Mathf.Sign(radsPerSecond);
        var carAngle = Vector3.SignedAngle(rb.velocity, rb.transform.forward, Vector3.up);
        var newBrakeForce = brakeForce;
        if (ABS)
        {
            if (carAngle > 2f)
            {
                newBrakeForce = 0;
                if (isLeft)
                {
                    newBrakeForce = brakeForce;
                }
            }
            else if (carAngle < -2f)
            {
                newBrakeForce = brakeForce;
                if (isLeft)
                {
                    newBrakeForce = 0;
                }
            }
        }

        if (brake > 0.3f && throttle > 0.3f)
        {
            radsPerSecond -= (motorPower * 2) * Mathf.Pow(throttle, motorFactor) / inertia * Time.deltaTime;

        }
        else
        {
            radsPerSecond += newBrakeForce * Mathf.Pow(brake, brakeFactor) / inertia * Time.deltaTime * -oldSign;
        }


        if (Mathf.Sign(radsPerSecond) != oldSign)
        {
            radsPerSecond = 0;
        }



        if (spring.IsGrounded)
        {
            var pointVel = rb.GetPointVelocity(spring.hitPoint);
            if (spring.LastHitRb)
                pointVel -= spring.LastHitRb.GetPointVelocity(spring.hitPoint);
            forwardVel = Vector3.Dot(pointVel, spring.transform.TransformDirection(Vector3.forward));
            lateralVel = Vector3.Dot(pointVel, spring.transform.TransformDirection(Vector3.right));
            var spin = tire.radius * radsPerSecond - forwardVel;
            if (spin > maxOverspin && radsPerSecond != 0)
            {
                radsPerSecond = (forwardVel + maxOverspin) / tire.radius;
            }
            forwardSlip = (-(forwardVel - tire.radius * radsPerSecond)) / (tire.radius * Mathf.Abs(radsPerSecond) + minVel);// * Mathf.Sign(radsPerSecond);
            LateralSlip = (-lateralVel) / (tire.radius * Mathf.Abs(radsPerSecond) + minVel);
            if (normalize)
            {
                var normalized = new Vector2(forwardSlip, LateralSlip).normalized;
                forwardSlip = normalized.x;
                LateralSlip = normalized.y;
            }
            forwardForce = tire.GetForwardForce(forwardSlip, spring.springLoad);
            lateralForce = tire.GetLateralForce(LateralSlip, spring.springLoad);
            rollingTorque = GetRollingTorque(forwardForce, inertia);
            var angle = rollingTorque / inertia;
            radsPerSecond += (angle * Time.deltaTime);
        }
        else
        {
            forwardVel = 0;
            lateralVel = 0;
            forwardSlip = 0;
            LateralSlip = 0;
            forwardForce = 0;
            lateralForce = 0;
        }

        if (test)
        {
            forwardForce = 0;
            lateralForce = 0;
        }



        //accelFactor -= decelFactor * Time.deltaTime;
    }
    public void ApplyForce()
    {
        var forcePoint = spring.hitPoint - (spring.transform.up * tire.radius);
        rb.AddForceAtPosition(forwardForce * transform.forward, forcePoint, ForceMode.Force);
        rb.AddForceAtPosition(lateralForce * transform.right, forcePoint, ForceMode.Force);
        if (spring.IsGrounded && spring.LastHitRb)
        {
            spring.LastHitRb.AddForceAtPosition(-forwardForce * transform.forward, spring.hitPoint);
            spring.LastHitRb.AddForceAtPosition(-lateralForce * transform.right, spring.hitPoint);
        }
    }

}
