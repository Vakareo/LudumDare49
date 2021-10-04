using UnityEngine;

public class UnstableItem : MonoBehaviour
{
    public float maxShakeValue = 1f;
    private Vector3 intialPosition;
    private void Awake()
    {
        intialPosition = transform.position;
    }
    public void ApplyInstability(float value)
    {
        var shake = maxShakeValue - (maxShakeValue * value);
        var direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        transform.position = intialPosition + direction * shake;
    }
}