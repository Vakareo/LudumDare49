using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpringAndDamper))]
public class TireForce : MonoBehaviour, ITire, IInputUpdate
{
    private MyInputsObject inputs;
    private SpringAndDamper spring;
    private Rigidbody rb;
    public TireData tire;
    public float power;
    public float minVel = 0.001f;
    public bool test;
    public float radsPerSecond;
    private float forwardSlip;
    private float lateralSlip;
    private float forwardVel;
    private float lateralVel;
    private float forwardForce;
    private float lateralForce;
    private float rollingTorque;
    public float accelFactor;
    public float decelFactor;

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
        accelFactor = inputs.myInputs.Base.Vertical.ReadValue<float>();
    }

    private float GetRollingTorque(float forwardForce)
    {
        var accel = (-forwardForce) / (tire.mass * tire.radius);
        var inertia = tire.mass * Mathf.Pow(tire.radius, 2f);
        var myTorque = inertia * accel;
        //AppliedTorque += myTorque;
        //FeedbackTorque = 0;
        //if (accel <= 0)
        //    FeedbackTorque = Mathf.Abs(inertia * accel);
        return myTorque;// + FeedbackTorque;
    }

    public void PhysicsUpdate()
    {
        accelFactor = Mathf.Clamp(accelFactor, -1, 1);
        radsPerSecond += accelFactor * power * Time.deltaTime;

        if (spring.IsGrounded)
        {
            var pointVel = rb.GetPointVelocity(spring.hitPoint);
            forwardVel = Vector3.Dot(pointVel, spring.transform.TransformDirection(Vector3.forward));
            lateralVel = Vector3.Dot(pointVel, spring.transform.TransformDirection(Vector3.right));
            forwardSlip = (-(forwardVel - tire.radius * radsPerSecond)) / (tire.radius * Mathf.Abs(radsPerSecond) + minVel);// * Mathf.Sign(radsPerSecond);
            lateralSlip = (-lateralVel) / (tire.radius * Mathf.Abs(radsPerSecond) + minVel);
            forwardForce = tire.GetForwardForce(forwardSlip, spring.springLoad);
            lateralForce = tire.GetLateralForce(lateralSlip, spring.springLoad);
            rollingTorque = GetRollingTorque(forwardForce);
            var inertia = tire.mass * Mathf.Pow(tire.radius, 2);
            var angle = rollingTorque / inertia;
            radsPerSecond += (angle * Time.deltaTime);
        }
        else
        {
            forwardVel = 0;
            lateralVel = 0;
            forwardSlip = 0;
            lateralSlip = 0;
            forwardForce = 0;
            lateralForce = 0;
        }

        if (test)
        {
            forwardForce = 0;
        }

        //accelFactor -= decelFactor * Time.deltaTime;
    }
    public void ApplyForce()
    {
        var forcePoint = spring.hitPoint - (spring.transform.up * tire.radius);
        rb.AddForceAtPosition(forwardForce * transform.forward, forcePoint, ForceMode.Force);
        rb.AddForceAtPosition(lateralForce * transform.right, forcePoint, ForceMode.Force);
        if (spring.IsGrounded && spring.lastHitRb)
        {
            spring.lastHitRb.AddForceAtPosition(-forwardForce * transform.forward, spring.hitPoint);
            spring.lastHitRb.AddForceAtPosition(-lateralForce * transform.right, spring.hitPoint);
        }
    }

}
