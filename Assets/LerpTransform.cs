using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTransform : MonoBehaviour
{
    public float time = 1;
    public Vector3 ToPosition;
    public Vector3 ToRotation;
    private bool on;
    private float startTime;

    private WaitForEndOfFrame wait = new WaitForEndOfFrame();
    private Vector3 initialPosition;
    private Vector3 initialRotation;

    private Vector3 GetInitialPosition()
    {
        return initialPosition;
    }

    private void Awake()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localEulerAngles;
    }

    public void SetValue(float value)
    {
        transform.localPosition = Vector3.Lerp(initialPosition, ToPosition, value);
        transform.localEulerAngles = Vector3.Slerp(initialRotation, ToRotation, value);
    }


    public void Toggle(bool value)
    {
        on = value;
        if (on)
        {
            StopAllCoroutines();
            startTime = 0;
            StartCoroutine(TurnOn());
        }
        else
        {
            StopAllCoroutines();
            startTime = 0;
            StartCoroutine(TurnOff());
        }


    }

    IEnumerator TurnOn()
    {
        while (startTime <= time)
        {
            startTime += Time.deltaTime;
            var lerp = startTime / time;
            transform.localPosition = Vector3.LerpUnclamped(initialPosition, ToPosition, lerp);
            transform.localEulerAngles = Vector3.SlerpUnclamped(initialRotation, ToRotation, lerp);
            yield return wait;
        }
    }
    IEnumerator TurnOff()
    {
        while (startTime <= time)
        {
            startTime += Time.deltaTime;
            var lerp = startTime / time;
            transform.localPosition = Vector3.LerpUnclamped(ToPosition, initialPosition, lerp);
            transform.localEulerAngles = Vector3.SlerpUnclamped(ToRotation, initialRotation, lerp);
            yield return wait;
        }
    }
}
