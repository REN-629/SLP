using UnityEngine;

public class raindelete : MonoBehaviour
{
    private float bottomLimit = -10.0f; // ‰ºŒÀ

    private void Update()
    {
        if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}
