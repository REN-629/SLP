using UnityEngine;

//�S�[�����ɉԉ΂̃p�[�e�B�N���A�A���ŃS�[������ɐG��Ă���񂵂��Đ�����Ȃ�

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