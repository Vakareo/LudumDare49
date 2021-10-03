using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    private ICarSpring[] springs;
    private ITire[] tires;
    private IInterp[] interps;
    private IInputUpdate[] inputs;
    private void Start()
    {
        springs = GetComponentsInChildren<ICarSpring>();
        tires = GetComponentsInChildren<ITire>();
        interps = GetComponentsInChildren<IInterp>();
        inputs = GetComponentsInChildren<IInputUpdate>();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i].InputUpdate();
        }
        for (int i = 0; i < springs.Length; i++)
        {
            springs[i].PhysicsUpdate();
        }
        for (int i = 0; i < tires.Length; i++)
        {
            tires[i].PhysicsUpdate();
        }
        for (int i = 0; i < tires.Length; i++)
        {
            tires[i].ApplyForce();
        }
        for (int i = 0; i < springs.Length; i++)
        {
            springs[i].ApplyForce();
        }
        for (int i = 0; i < interps.Length; i++)
        {
            interps[i].UpdateInterp();
        }

    }
}
