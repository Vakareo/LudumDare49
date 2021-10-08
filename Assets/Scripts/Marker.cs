using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
[ExecuteAlways]
public class Marker : ImmediateModeShapeDrawer
{
    public float speed = 1f;
    public float radius = 2f;
    public float thickness = 0.5f;
    public int count = 3;
    public Color color = Color.magenta;

    private float currentTime;
    public bool billboard;

    public override void DrawShapes(Camera cam)
    {
        using (Draw.Command(cam))
        {
            currentTime += Time.deltaTime;
            if (currentTime > 1f)
                currentTime = 0;

            Draw.Ring(transform.position, transform.up, radius * currentTime, thickness * currentTime, color);


        }
    }

}
