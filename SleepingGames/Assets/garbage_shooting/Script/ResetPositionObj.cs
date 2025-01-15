using UnityEngine;

public class ResetPositionObj : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        // 初期位置を記録
        initialPosition = transform.position;
        // 10秒後にResetObjectPosition関数を呼び出す
        Invoke("ResetObjectPosition", 10.0f);
    }

    void ResetObjectPosition()
    {
        // オブジェクトを初期位置に戻す
        transform.position = initialPosition;
    }
}
