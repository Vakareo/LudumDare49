using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class RigidbodyForwardSpeedUI : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (rb)
        {
            text.text = (Mathf.Abs(Vector3.Dot(rb.velocity, rb.transform.forward)) * 2.236936f).ToString("0") + "MPH";
        }

    }
}
