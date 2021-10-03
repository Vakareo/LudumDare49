using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpringAndDamper))]
[RequireComponent(typeof(TireForce))]
public class TireVisual : MonoBehaviour, IInterp
{
    [SerializeField] Transform tireModel;
    private SpringAndDamper spring;
    private TireForce tire;
    private float currentTireSpeed;
    private float lastTireSpeed;
    private float currentSpringDistance;
    private float newTime;
    private float oldTime;
    private float lastSpringDistance;
    private float interpFactor;

    private void Awake()
    {
        tire = GetComponent<TireForce>();
        spring = GetComponent<SpringAndDamper>();
        lastSpringDistance = spring.maxHeight;
        lastTireSpeed = 0;
    }

    public void UpdateInterp()
    {
        oldTime = newTime;
        lastSpringDistance = currentSpringDistance;
        currentSpringDistance = spring.CurrentHitDistance - spring.tire.radius;
        lastTireSpeed = currentTireSpeed;
        currentTireSpeed = tire.radsPerSecond;
        newTime = Time.fixedTime;
    }

    private void Update()
    {
        if (newTime != oldTime)
        {
            interpFactor = (Time.time - newTime) / (newTime - oldTime);
        }
        else
        {
            interpFactor = 1f;
        }

        var distance = Mathf.Lerp(lastSpringDistance, currentSpringDistance, interpFactor);
        var wheelSpeed = Mathf.Lerp(lastTireSpeed, currentTireSpeed, interpFactor);
        tireModel.position = spring.transform.position - (spring.transform.up * distance);
        //tireModel.localEulerAngles = new Vector3(tireModel.localEulerAngles.x, tire.transform.localEulerAngles.y, tireModel.localEulerAngles.z);
        tireModel.RotateAroundLocal(Vector3.right, wheelSpeed * Time.deltaTime);
    }


}
