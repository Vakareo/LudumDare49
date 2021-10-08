using UnityEngine;

public class UnstableItem : MonoBehaviour
{
    public float maxShakeSpeed = 5f;
    public float maxRotateSpeed = 90f;
    private Vector3 direction;
    private int directionCount;

    public void ApplyInstability(float value)
    {
        var shake = maxShakeSpeed - (maxShakeSpeed * value);
        var rotate = maxRotateSpeed - (maxRotateSpeed * value);


        transform.position += direction * shake;
        transform.eulerAngles += direction * rotate;
    }

    internal void UpdateDirection()
    {
        directionCount++;
        if ((directionCount & 1) == 1)
        {
            direction = -direction;
        }
        else
        {
            direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
    }
}