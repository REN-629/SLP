using UnityEngine;

public class ResetPositionObj : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        // �����ʒu���L�^
        initialPosition = transform.position;
        // 10�b���ResetObjectPosition�֐����Ăяo��
        Invoke("ResetObjectPosition", 10.0f);
    }

    void ResetObjectPosition()
    {
        // �I�u�W�F�N�g�������ʒu�ɖ߂�
        transform.position = initialPosition;
    }
}
