using UnityEngine;

public class turn : MonoBehaviour
{
    // ��]���x��ݒ肷�邽�߂̕ϐ�
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);

    void Update()
    {
        // ���t���[���A�w�肵�����x�ŃI�u�W�F�N�g����]������
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}