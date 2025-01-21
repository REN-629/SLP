using UnityEngine;

//�I�u�W�F�N�g�ɏՓ˂������T�E���h��炷
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