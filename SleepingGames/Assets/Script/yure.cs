using UnityEngine;

public class yure : MonoBehaviour
{
    public yurecamera cameraShake;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(cameraShake.Shake(shakeDuration, shakeMagnitude));
    }
}