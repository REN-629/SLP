using UnityEngine;

public class yure : MonoBehaviour
{
    public yurecamera cameraShake;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.01f;
    public string ignoreTag = "NoShake"; // �h�炳�Ȃ��I�u�W�F�N�g�̃^�O

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂����I�u�W�F�N�g������̃^�O�������Ă���ꍇ�A�h��𖳌��ɂ���
        if (collision.gameObject.CompareTag(ignoreTag))
        {
            return;
        }

        StartCoroutine(cameraShake.Shake(shakeDuration, shakeMagnitude));
    }
}