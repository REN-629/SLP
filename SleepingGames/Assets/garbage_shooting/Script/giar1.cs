using UnityEngine;

//G�L�[�Ŏ��Ԃ����v���ɉ�]
public class giar1 : MonoBehaviour
{
    public Transform triangleTransform;
    public float rotationSpeed = 45f; // 1�b������̉�]�p�x

    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            triangleTransform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}