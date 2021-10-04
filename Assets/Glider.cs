using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Glider : MonoBehaviour
{
    public Transform leftWing;
    public Transform rightWing;

    public float damper = 1500f;
    public float scaledTorque = 20f;
    [Range(0, 300)]
    public float maxLiftSpeed = 120f;
    public bool glide = true;

    private Rigidbody rb;

    [Range(5, 90)]
    public float maxRoll = 15f;
    public float scaledLift = 1;
    public AnimationCurve liftCurve;
    private MyInputsObject inputs;
    private float rollAngle;
    private float pitchAngle;
    private float yawAngle;
    public bool twist = true;

    private float lastRollAngle;
    private float lastPitchAngle;
    private Vector3 initialLeftWingPos;
    private Vector3 initialRightWingPos;
    private float lastYawAngle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputs = FindObjectOfType<MyInputsObject>();
        if (leftWing)
            initialLeftWingPos = leftWing.localPosition;
        if (rightWing)
            initialRightWingPos = rightWing.localPosition;

        SetWings();
    }
    private void OnEnable()
    {
        inputs.myInputs.Base.ToggleGlide.performed += ToggleGlide;
    }

    private void ToggleGlide(InputAction.CallbackContext obj)
    {
        glide = !glide;
        SetWings();
    }

    private void SetWings()
    {
        if (leftWing)
        {
            if (glide)
            {
                leftWing.localPosition = initialLeftWingPos + Vector3.right * -1.7f;
            }
            else
            {
                leftWing.localPosition = initialLeftWingPos;
            }
        }
        if (rightWing)
        {
            if (glide)
            {
                rightWing.localPosition = initialRightWingPos + Vector3.right * 1.7f;
            }
            else
            {
                rightWing.localPosition = initialRightWingPos;
            }
        }
    }

    private void OnDisable()
    {

        inputs.myInputs.Base.ToggleGlide.performed -= ToggleGlide;
    }

    private void FixedUpdate()
    {
        var turnInput = inputs.myInputs.Base.Horizontal.ReadValue<float>();

        var flatUp = new Vector3(0, rb.transform.up.y, rb.transform.up.z).normalized;
        var flatForward = new Vector3(rb.transform.forward.x, 0, rb.transform.forward.z).normalized;
        var flatRight = new Vector3(rb.transform.right.x, 0, rb.transform.right.z).normalized;
        rollAngle = Vector3.SignedAngle(flatUp, rb.transform.up, flatForward);
        pitchAngle = Vector3.SignedAngle(flatForward, rb.transform.forward, flatRight);
        yawAngle = Vector3.SignedAngle(rb.transform.forward, rb.velocity, flatUp);
        var rollVelocity = (lastRollAngle - rollAngle) / Time.deltaTime;
        var pitchVelocity = (lastPitchAngle - pitchAngle) / Time.deltaTime;
        var yawVelocity = (lastYawAngle - yawAngle) / Time.deltaTime;

        if (glide)
        {
            var massTorque = rb.mass * Physics.gravity.magnitude;
            var speedLift = Mathf.Abs(new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude);//Vector3.Dot(new Vector3(rb.velocity.x, 0, rb.velocity.z), rb.transform.forward));
            var liftFactor = liftCurve.Evaluate(Mathf.Clamp(speedLift / maxLiftSpeed, 0, maxLiftSpeed)) * scaledLift;
            var lift = liftFactor * massTorque;
            var maxTorque = scaledTorque * rb.mass;
            rb.AddTorque(rb.transform.right * (maxTorque * liftFactor * -pitchAngle + (Mathf.Clamp01(pitchVelocity / 5f) * Mathf.Sign(pitchVelocity) * damper * liftFactor)));
            rb.AddTorque(rb.transform.forward * (maxTorque * liftFactor * -rollAngle + (Mathf.Clamp01(rollVelocity / 5f) * Mathf.Sign(rollVelocity) * damper * liftFactor)));
            rb.AddForce(lift * rb.transform.up);
            //rb.AddForce(liftFactor * rollForce * Mathf.Clamp01(rollAngle / maxRoll) * Mathf.Sign(rollAngle) * massTorque * Vector3.right);
            //rb.AddForce(liftFactor * yawForce * Mathf.Clamp01(yawAngle / 3f) * Mathf.Sign(yawAngle) * massTorque * Vector3.right);

            if (twist)
            {
                rb.AddTorque(rb.transform.up * ((maxTorque * liftFactor * yawAngle + (Mathf.Clamp01(yawVelocity / 5f) * -Mathf.Sign(yawVelocity) * damper * liftFactor)))); //+ (turnInput * massTorque * liftFactor * turnRate * Time.deltaTime)));
            }

        }

        lastRollAngle = rollAngle;
        lastPitchAngle = pitchAngle;
        lastYawAngle = yawAngle;
    }
}

