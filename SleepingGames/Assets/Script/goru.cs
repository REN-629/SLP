using UnityEngine;

public class goru : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip collisionSound;

    void OnTriggerEnter(Collider other)
    {
        // 当たったオブジェクトが「gomibako」タグを持っているか確認
        if (other.CompareTag("gomibako"))
        {
            // サウンドを再生
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
