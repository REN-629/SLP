using UnityEngine;

//重力変更時に三角の向きを変える

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