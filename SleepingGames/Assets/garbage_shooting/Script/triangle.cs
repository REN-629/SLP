using UnityEngine;

//�d�͕ύX���ɎO�p�̌�����ς���

public class triangle : MonoBehaviour
{
    public Transform triangleTransform;
    private bool isReversed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            isReversed = !isReversed;
            triangleTransform.rotation = isReversed ? Quaternion.Euler(0, 0, 180) : Quaternion.identity;
        }
    }
}