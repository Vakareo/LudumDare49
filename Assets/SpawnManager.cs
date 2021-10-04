using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public List<SpawnLocation> carSpawns;
    public List<SpawnLocation> trailerSpawns;
    public List<SpawnLocation> deviceSpawns;

    public SpawnLocation customCar;
    public SpawnLocation customTrailer;
    public SpawnLocation customDevice;

    public GameObject car;
    public GameObject trailer;
    public GameObject device;

    private Rigidbody carRB;
    private Rigidbody trailerRB;
    private Rigidbody deviceRB;
    private MyInputsObject myInputs;

    private void Awake()
    {
        carRB = car.GetComponent<Rigidbody>();
        trailerRB = trailer.GetComponent<Rigidbody>();
        deviceRB = device.GetComponent<Rigidbody>();
        SetCustom();
        AddSpawnLocation();
        myInputs = FindObjectOfType<MyInputsObject>();
    }

    private void Start()
    {

    }

    private void OnEnable()
    {
        myInputs.myInputs.Base.SetSpawn.performed += SetSpawnEvent;
        myInputs.myInputs.Base.Spawn.performed += SpawnEvent;
    }

    private void SpawnEvent(InputAction.CallbackContext obj)
    {
        SpawnCustom();
    }

    private void SetSpawnEvent(InputAction.CallbackContext obj)
    {
        SetCustom();
    }

    private void OnDisable()
    {
        myInputs.myInputs.Base.SetSpawn.performed -= SetSpawnEvent;
        myInputs.myInputs.Base.Spawn.performed -= SpawnEvent;
    }

    [ContextMenu("set")]
    public void SetCustom()
    {
        customCar = new SpawnLocation(car.transform.position, car.transform.rotation);
        customTrailer = new SpawnLocation(trailer.transform.position, trailer.transform.rotation);
        customDevice = new SpawnLocation(device.transform.position, device.transform.rotation);
    }

    public void AddSpawnLocation()
    {
        carSpawns.Add(new SpawnLocation(car.transform.position, car.transform.rotation));
        trailerSpawns.Add(new SpawnLocation(trailer.transform.position, trailer.transform.rotation));
        deviceSpawns.Add(new SpawnLocation(device.transform.position, device.transform.rotation));
    }

    [ContextMenu("spawn")]
    public void SpawnCustom()
    {
        SpawnCar(customCar);
        SpawnTrailer(customTrailer);
        SpawnDevice(customDevice);
    }

    private void SpawnCar(SpawnLocation loc)
    {
        car.transform.position = loc.position;
        car.transform.rotation = loc.rotation;
        carRB.velocity = Vector3.zero;
        carRB.angularVelocity = Vector3.zero;
    }
    private void SpawnTrailer(SpawnLocation loc)
    {
        trailer.transform.position = loc.position;
        trailer.transform.rotation = loc.rotation;
        trailerRB.velocity = Vector3.zero;
        trailerRB.angularVelocity = Vector3.zero;
    }
    private void SpawnDevice(SpawnLocation loc)
    {
        device.transform.position = loc.position;
        device.transform.rotation = loc.rotation;
        deviceRB.velocity = Vector3.zero;
        deviceRB.angularVelocity = Vector3.zero;
    }

    public void SpawnAt(int index)
    {
        SpawnCar(carSpawns[index]);
        SpawnTrailer(trailerSpawns[index]);
        SpawnDevice(deviceSpawns[index]);
    }

}

[System.Serializable]
public struct SpawnLocation
{
    public Vector3 position;
    public Quaternion rotation;

    public SpawnLocation(Vector3 position, Quaternion rotation)
    {
        this.position = position;
        this.rotation = rotation;
    }
}
