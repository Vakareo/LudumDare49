using UnityEngine;

public class UnstableItem : MonoBehaviour
{
    public float maxShakeValue = 1f;
    public void ApplyInstability(float value)
    {
        var shake = maxShakeValue - (maxShakeValue * value);
        var direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        transform.localPosition = direction * shake;
    }
}