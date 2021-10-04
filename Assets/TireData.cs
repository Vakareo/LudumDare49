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
    public float maxGripForwardSlip = 0;
    public float maxGripLateralSlip = 0;

    private void OnValidate()
    {
        maxGripForwardSlip = GetForwardHighestValue();
        maxGripLateralSlip = GetLateralHighestValue();
    }

    private float GetForwardHighestValue()
    {
        var value = 0f;
        var highestEval = 0f;
        for (int i = 0; i < 40; i++)
        {
            var eval = (float)i / 39f;
            var point = forwardCurve.Evaluate(eval);
            if (point > value)
            {
                value = point;
                highestEval = eval;
            }
        }

        return highestEval;
    }
    private float GetLateralHighestValue()
    {
        var value = 0f;
        var highestEval = 0f;
        for (int i = 0; i < 40; i++)
        {
            var eval = (float)i / 39f;
            var point = lateralCurve.Evaluate(eval);
            if (point > value)
            {
                value = point;
                highestEval = eval;
            }
        }

        return highestEval;
    }

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
