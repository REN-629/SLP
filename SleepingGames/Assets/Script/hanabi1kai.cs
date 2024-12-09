using UnityEngine;

public class hanabi1kai : MonoBehaviour
{
    public ParticleSystem particleEffect;
    private bool hasPlayed = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasPlayed && collision.gameObject.CompareTag("gomibako"))
        {
            particleEffect.transform.position = transform.position;
            particleEffect.Play();
            hasPlayed = true;
        }
    }
}