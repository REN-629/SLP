using UnityEngine;

public class sankaku : MonoBehaviour
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