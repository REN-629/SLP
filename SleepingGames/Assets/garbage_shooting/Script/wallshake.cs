using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallshake : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("tukue"))
        {
            // オブジェクトを揺らすエフェクトを追加
            StartCoroutine(Shake());
        }
    }

    private IEnumerator Shake()
    {
        Vector3 originalPosition = transform.position;
        float duration = 0.5f;
        float magnitude = 0.1f;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
    }
}
