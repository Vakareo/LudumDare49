using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightPulser : MonoBehaviour
{
    private Light light;
    public float intensity;
    public float rate;
    private int count;
    private float currentTime;
    private void Awake()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > rate)
        {
            count++;
            currentTime = 0;
        }
        var lerp = 0f;

        if ((count & 1) == 1)
        {
            lerp = 1f - (currentTime / rate);
        }
        else
        {
            lerp = (currentTime / rate);
        }

        light.intensity = Mathf.Lerp(0, intensity, lerp);

    }
}
