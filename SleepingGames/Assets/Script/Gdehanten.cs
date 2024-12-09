using UnityEngine;

public class Gdehanten : MonoBehaviour
{
    public AreaEffector2D areaEffector;
    public SpriteRenderer spriteRenderer;
    private bool isReversed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            isReversed = !isReversed;
            areaEffector.forceAngle = isReversed ? 270f : 90f;
            spriteRenderer.color = isReversed ? new Color(0.5f, 0.5f, 1f, 0.5f) : new Color(1f, 0.5f, 0.5f, 0.5f);
        }
    }
}