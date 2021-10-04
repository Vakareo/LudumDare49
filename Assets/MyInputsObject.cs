using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-9999)]
public class MyInputsObject : MonoBehaviour
{
    public MyInputs myInputs { get; private set; }
    private void Awake()
    {
        DontDestroyOnLoad(this);
        myInputs = new MyInputs();
    }

    private void OnEnable()
    {
        foreach (var item in myInputs.Base.Get())
        {
            item.Enable();
        }
    }
    private void OnDisable()
    {
        foreach (var item in myInputs.Base.Get())
        {
            item.Disable();
        }
    }
}
