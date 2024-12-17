using UnityEngine;

public class yure : MonoBehaviour
{
    public yurecamera cameraShake;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.01f;
    public string ignoreTag = "NoShake"; // 揺らさないオブジェクトのタグ

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトが特定のタグを持っている場合、揺れを無効にする
        if (collision.gameObject.CompareTag(ignoreTag))
        {
            return;
        }

        StartCoroutine(cameraShake.Shake(shakeDuration, shakeMagnitude));
    }
}
