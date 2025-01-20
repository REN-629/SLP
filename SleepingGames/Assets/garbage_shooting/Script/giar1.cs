using UnityEngine;

//GƒL[‚Å•Ô‚ªŒv‰ñ‚è‚É‰ñ“]
public class giar1 : MonoBehaviour
{
    public Transform triangleTransform;
    public float rotationSpeed = 45f; // 1•b‚ ‚½‚è‚Ì‰ñ“]Šp“x

    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            triangleTransform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}