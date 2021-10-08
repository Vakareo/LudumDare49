using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpawnManager spawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Car>(out Car car))
        {
            spawner.SetCustom();
        }
    }
}
