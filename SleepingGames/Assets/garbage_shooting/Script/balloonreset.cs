using UnityEngine;

public class balloonreset : MonoBehaviour
{
    public float minX = -3.5f;
    public float maxX = 3.4f;
    public float fixedY = -8f; // Yç¿ïWÇå≈íËÇ∑ÇÈèÍçá

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("ground"))
        {
            Debug.Log("Collision detected with husen tag");
            float randomX = Random.Range(minX, maxX);
            transform.position = new Vector3(randomX, fixedY, transform.position.z);
        }
    }
}
