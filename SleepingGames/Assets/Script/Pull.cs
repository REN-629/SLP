using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    Rigidbody2D rigid2d;
    Vector2 startPos;
    float speed = 0;
    bool shotGaugeSet = false;
    bool isShooting = false;

    void Start()
    {
        this.rigid2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 発射中でない場合のみ、マウス入力を受け付ける
        if (!isShooting)
        {
            // マウスを押した地点の座標を記録
            if (Input.GetMouseButtonDown(0))
            {
                this.startPos = Input.mousePosition;
                shotGaugeSet = true;
                Debug.Log("Mouse down at: " + startPos);
            }

            // マウスを離した地点の座標から、発射方向を計算
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 endPos = Input.mousePosition;
                Vector2 direction = (startPos - endPos).normalized;
                float distance = Vector2.Distance(startPos, endPos);  // 距離を計算
                speed = distance * 2;  // 距離に応じてスピードを設定
                this.rigid2d.AddForce(direction * speed);
                shotGaugeSet = false;
                isShooting = true;  // 発射中に設定
                Debug.Log("Mouse up at: " + endPos);
                Debug.Log("Direction: " + direction);
                Debug.Log("Distance: " + distance);
                Debug.Log("Speed: " + speed);
            }
        }

        // テスト用：スペースキー押下で停止
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2d.velocity *= 0;
            isShooting = false;  // 発射停止
            Debug.Log("Space key pressed: Velocity set to 0");
        }
    }

    void FixedUpdate()
    {
        this.rigid2d.velocity *= 0.995f;
    }
}
