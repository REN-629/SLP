using UnityEngine;

//オブジェクトに衝突した時サウンドを鳴らす
public class SE : MonoBehaviour
{
    public AudioClip collisionSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = collisionSound;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
    }
}