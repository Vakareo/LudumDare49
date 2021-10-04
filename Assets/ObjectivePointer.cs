using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

[ExecuteAlways]
public class ObjectivePointer : ImmediateModeShapeDrawer
{
    public Transform objective;
    public float width = 0.2f;
    public float pointLength = 0.2f;
    public Color farColor = Color.magenta;
    public Color closeColor = Color.green;
    public float far = 1000f;
    public float lerpPow = 1f;
    public bool is3D = false;
    public bool isCone = false;

    public override void DrawShapes(Camera cam)
    {
        var direction = objective.position - transform.position;
        var distance = direction.magnitude;

        if (!is3D)
        {
            direction = new Vector3(objective.position.x, 0, objective.position.z) - new Vector3(transform.position.x, 0, transform.position.z);
            distance = direction.magnitude;
        }

        direction.Normalize();


        var right = Vector3.Cross(direction, Vector3.up);
        if (is3D)
            right = transform.right;
        var lerp = Mathf.Pow(distance / far, lerpPow);
        var color = Color.LerpUnclamped(closeColor, farColor, lerp);
        using (Draw.Command(cam))
        {
            if (is3D && !isCone)
            {
                Draw.Triangle(transform.position + (right * (-width * 0.5f)), transform.position + (direction * pointLength), transform.position + (right * (width * 0.5f)), color);
            }
            else if (!isCone)
            {
                Draw.Triangle(transform.position + Vector3.ProjectOnPlane(right * (-width * 0.5f), transform.up), transform.position + Vector3.ProjectOnPlane((direction * pointLength), transform.up), transform.position + Vector3.ProjectOnPlane(right * (width * 0.5f), transform.up), color);
            }

            if (isCone)
            {
                Draw.Cone(transform.position, direction, width * 0.5f, pointLength, true, color);
            }
        }
    }

}
