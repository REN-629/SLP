using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float amplitude = 1f; // 移動の幅
    public float speed = 1f; // 移動の速さ

    private Vector3 startPos;

    void Start()
    {
        // オブジェクトの初期位置を保存
        startPos = transform.position;
    }

    void Update()
    {
        // オブジェクトを上下に動かす
        float newY = startPos.y + amplitude * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
