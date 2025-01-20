using UnityEngine;

//Gキーで歯車が反時計回りに回転
public class giar2 : MonoBehaviour
{
    public Transform triangleTransform;
    public float rotationSpeed = 45f; // 1秒あたりの回転角度

    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            triangleTransform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }
}
