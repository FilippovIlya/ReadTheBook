

using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public bool randomRotationEnabled;
    public float rotationsPerMinuteMax;
    public bool rotationEnabled = false;
    public float rotationsPerMinute = 0f;

    void Start()
    {
        if (randomRotationEnabled)
        {
            rotationsPerMinute = Random.Range(rotationsPerMinute, rotationsPerMinuteMax);
        }
    }

    void Update()
    {
        if (rotationEnabled)
        {
            transform.Rotate(0, 0, rotationsPerMinute * Time.deltaTime, Space.Self);
        }
    }
}
