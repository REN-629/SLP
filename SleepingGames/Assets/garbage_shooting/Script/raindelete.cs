using UnityEngine;

//rain�X�N���v�g�ŕ��������I�u�W�F�N�g����ʊO�ɏo���ꍇ�폜����
public class raindelete : MonoBehaviour
{
    private float bottomLimit = -10.0f; // ����

    private void Update()
    {
        if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}
