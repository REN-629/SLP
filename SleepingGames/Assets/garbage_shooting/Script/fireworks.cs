using UnityEngine;

//�S�[�����ɉԉ΂̃p�[�e�B�N��

public class fireworks : MonoBehaviour
{
    public ParticleSystem particleEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("gomibako"))
        {
            particleEffect.transform.position = transform.position;
            particleEffect.Play();
        }
    }
}