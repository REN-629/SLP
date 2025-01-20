using UnityEngine;

//ゴール時に花火のパーティクル、連続でゴール判定に触れても一回しか再生されない

public class fireworks1 : MonoBehaviour
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