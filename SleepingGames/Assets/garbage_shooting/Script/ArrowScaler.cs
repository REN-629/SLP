using UnityEngine;

public class ArrowScaler : MonoBehaviour
{
    public float maxLength = 3.0f; // Å‘å’·‚³
    public float minLength = 0.0f; // Å¬’·‚³
    private bool isShooting = false; // ”­Ë’†‚©‚Ç‚¤‚©‚ğ’ÇÕ

    public void SetLength(float length)
    {
        if (!isShooting)
        {
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Clamp(length, minLength, maxLength);
            transform.localScale = scale;
        }
    }

    public void SetRotation(Vector3 direction)
    {
        if (!isShooting)
        {
            transform.up = direction; // –îˆó‚ÌŒü‚«‚ğİ’è
        }
    }

    public void StartShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }
}
