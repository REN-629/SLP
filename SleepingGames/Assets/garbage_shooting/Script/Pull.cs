using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pull : MonoBehaviour
{
    // 2Dリジットボディ
    Rigidbody2D rigid2d;
    // マウスを押したときの開始位置を記録する
    Vector2 startPos;
    // 発射速度を保持する
    float speed = 0;
    // マウス押されたかどうか追跡
    bool shotGaugeSet = false;
    // オブジェクト発射中かどうか
    bool isShooting = false;
    void Start()
    {
        // Rigidbody2Dコンポーネントを取得
        this.rigid2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 発射中でない場合のみ、マウス入力を処理
        if (!isShooting)
        {
            HandleMouseInput();
        }
        // スペースキー押下で発射を停止
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopShooting();
        }
    }

    void FixedUpdate()
    {
        // 摩擦を適用して速度を減少させる
        ApplyFriction();
    }
    void HandleMouseInput()
    {
        // マウスボタンが押されたときの処理
        if (Input.GetMouseButtonDown(0))
        {
            RecordStartPosition();
        }
        // マウスボタンが離されたときの処理
        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
    }
    void RecordStartPosition()
    {
        // マウスを押した地点の座標を記録
        this.startPos = Input.mousePosition;
        shotGaugeSet = true;
        Debug.Log("Mouse down at: " + startPos);
    }
    void Shoot()
    {
        // マウスを離した地点の座標から発射方向と速度を計算し、力を加える
        Vector2 endPos = Input.mousePosition;
        Vector2 direction = (startPos - endPos).normalized;

        float distance = Vector2.Distance(startPos, endPos);
        speed = distance * 2;

        this.rigid2d.AddForce(direction * speed);

        shotGaugeSet = false;
        isShooting = true;

        Debug.Log("Mouse up at: " + endPos);
        Debug.Log("Direction: " + direction);
        Debug.Log("Distance: " + distance);
        Debug.Log("Speed: " + speed);
    }

    void StopShooting()
    {
        // 発射を停止し、速度をゼロに設定
        this.rigid2d.velocity *= 0;
        isShooting = false;
        Debug.Log("Space key pressed: Velocity set to 0");
    }
    void ApplyFriction()
    {
        // 摩擦を適用して速度を徐々に減少させる
        this.rigid2d.velocity *= 0.995f;
    }
}
