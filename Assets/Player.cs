using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float maxTorque;
    public float maxForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void ApplyInstability(float value)
    {
        if (value == 1f)
            return;
        var torque = maxTorque - (maxTorque * value);
        var force = maxForce - (maxForce * value);
        var direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.AddTorque(direction * torque);
        rb.AddForce(direction * force);
    }

}