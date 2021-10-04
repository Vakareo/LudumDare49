using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-999)]
public class CubeSpawner : MonoBehaviour
{
    public int count;
    public float maxRange = 50;
    public float maxScale = 5;
    public float minScale = 1;
    public GameObject prefab;
    public Material[] materials;

    private void Awake()
    {
        for (int i = 0; i < count; i++)
        {
            var position = new Vector3(Random.Range(-maxRange, maxRange), transform.position.y, Random.Range(-maxRange, maxRange));
            var obj = Instantiate(prefab, position, Quaternion.identity, transform);
            obj.transform.localScale *= Random.Range(minScale, maxScale);
            obj.GetComponent<Renderer>().material = materials[Random.Range(0, materials.Length - 1)];
        }
    }

}
