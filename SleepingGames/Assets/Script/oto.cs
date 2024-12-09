using UnityEngine;

public class oto : MonoBehaviour
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