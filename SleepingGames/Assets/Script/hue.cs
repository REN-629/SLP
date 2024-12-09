using UnityEngine;

public class hue : MonoBehaviour
{
    public GameObject objectToDuplicate;
    public float duplicationInterval = 1f;

    void Start()
    {
        InvokeRepeating("DuplicateObject", duplicationInterval, duplicationInterval);
    }

    void DuplicateObject()
    {
        Instantiate(objectToDuplicate, transform.position, transform.rotation);
    }
}