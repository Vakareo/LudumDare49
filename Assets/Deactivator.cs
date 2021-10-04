using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivator : MonoBehaviour
{
    public float maxTime = 13f;
    private float currentTime;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > maxTime)
        {
            this.gameObject.SetActive(false);
        }
    }
}
