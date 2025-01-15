using UnityEngine;

public class HorizontalMover : MonoBehaviour
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
        // オブジェクトを左右に動かす
        float newX = startPos.x + amplitude * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(newX, startPos.y, startPos.z);
    }
}
