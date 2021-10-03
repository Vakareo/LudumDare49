using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringAndDamper : MonoBehaviour, ICarSpring
{
    public TireData tire;
    public float preloadForce;
    public float preloadHeight;
    public float maxHeight;
    public float springStiffness;
    public float maxDamperVelocity;
    public float damper;
    public AnimationCurve damperCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public LayerMask layerMask;
    public bool IsGrounded { get; private set; }
    private Rigidbody rb;
    private Vector3 springForce;
    public float CurrentHitDistance { get; private set; }
    private float velocity;

    public Vector3 hitPoint { get; private set; }

    private float lastHitDistance;

    public float springLoad { get; private set; }

    public Rigidbody lastHitRb;


    private RaycastHit hit;

    private void Awake()
    {
        rb = transform.root.GetComponent<Rigidbody>();
    }

    private float GetSpringDisplacement(float hitDistance)
    {
        return preloadHeight - (hitDistance - tire.radius);
    }

    public float GetSpringForce(float displacement)
    {
        return preloadForce + springStiffness * displacement;
    }

    public float GetMaxDistance()
    {
        return maxHeight;
    }

    public void HitUpdate()
    {

    }


    public void PhysicsUpdate()
    {

        if (Physics.Raycast(transform.position, -transform.up, out hit, GetMaxDistance(), layerMask))
        {
            IsGrounded = true;
            CurrentHitDistance = hit.distance;
            velocity = (lastHitDistance - CurrentHitDistance) / Time.deltaTime;
            hitPoint = hit.point;
            springForce = transform.up * Mathf.Max(GetSpringForce(GetSpringDisplacement(CurrentHitDistance)) + GetDamper(velocity), 0);
            if (hit.rigidbody)
            {
                hit.rigidbody.AddForceAtPosition(-springForce, hitPoint);

            }
            lastHitRb = hit.rigidbody;
        }
        else
        {
            IsGrounded = false;
            CurrentHitDistance = maxHeight;
            springForce = Vector3.zero;
        }

        lastHitDistance = CurrentHitDistance;
        springLoad = springForce.magnitude;
    }

    private float GetDamper(float velocity)
    {
        var sign = Mathf.Sign(velocity);
        return damperCurve.Evaluate(Mathf.Clamp01(Mathf.Abs(velocity / maxDamperVelocity))) * sign * damper;
    }

    public void ApplyForce()
    {
        rb.AddForceAtPosition(springForce, transform.position);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, -transform.up * CurrentHitDistance, Color.green);
    }
}
