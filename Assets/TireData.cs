using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TireData : ScriptableObject
{
    public float mass;
    public float radius;
    public float width;
    public AnimationCurve forwardCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public AnimationCurve lateralCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public float idealLoad = 3500;
    public float maxForwardForce = 3500;
    public float maxLateralForce = 3200;

    public float GetForwardForce(float slip, float load)
    {
        var slipSign = Mathf.Sign(slip);
        var force = forwardCurve.Evaluate(slip * slipSign) * maxForwardForce * slipSign;
        return (load / idealLoad) * force;
    }
    public float GetLateralForce(float slip, float load)
    {
        var slipSign = Mathf.Sign(slip);
        var force = lateralCurve.Evaluate(slip * slipSign) * maxForwardForce * slipSign;
        return (load / idealLoad) * force;
    }

}
