using UnityEngine;

public class turn : MonoBehaviour
{
    // 回転速度を設定するための変数
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);

    void Update()
    {
        // 毎フレーム、指定した速度でオブジェクトを回転させる
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}