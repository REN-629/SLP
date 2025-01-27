using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    Rigidbody2D rigid2d;         // Rigidbody2Dのコンポーネント
    Vector2 startPos;            // マウスを押したときの開始位置を記録する
    float speed = 0;             // 発射速度を保持する
    bool shotGaugeSet = false;   // マウス押されたかどうか追跡
    bool isShooting = false;     // オブジェクト発射中かどうか

    // Start関数 
    void Start() // Rigidbody2Dコンポーネントを取得する関数
    {
        this.rigid2d = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
    }

    // Update関数 
    void Update() // 各フレームでの更新処理を行う関数
    {
        if (!isShooting)    // 発射中でない場合のみ、マウス入力を処理
        {
            HandleMouseInput(); // マウス入力を処理する関数
        }
        if (Input.GetKeyDown(KeyCode.Space)) // スペースキー押下で発射を停止
        {
            StopShooting(); // 発射を停止する関数
        }
    }

    // FixedUpdate関数 
    void FixedUpdate() // 固定フレームレートでの更新処理を行う関数
    {
        ApplyFriction(); // 摩擦を適用して速度を減少させる関数
    }

    // HandleMouseInput関数 
    void HandleMouseInput() // マウスが押された位置を記録し離したときに発射する関数
    {
        if (Input.GetMouseButtonDown(0)) // マウスボタンが押されたときの処理
        {
            RecordStartPosition(); // 開始位置を記録する関数
        }
        if (Input.GetMouseButtonUp(0)) // マウスボタンが離されたときの処理
        {
            Shoot(); // 発射する関数
        }
    }

    // RecordStartPosition関数 
    void RecordStartPosition() // 開始位置を記録する関数
    {
        this.startPos = Input.mousePosition; // マウスを押した地点の座標を記録
        shotGaugeSet = true;
        Debug.Log("Mouse down at: " + startPos);
    }

    // Shoot関数 
    void Shoot() // マウスの位置から発射方向と速度を計算し、発射する関数
    {
        Vector2 endPos = Input.mousePosition; // マウスを離した地点の座標を取得
        Vector2 direction = (startPos - endPos).normalized; // 発射方向を計算
        float distance = Vector2.Distance(startPos, endPos); // マウスの移動距離を計算
        speed = distance * 2; // 発射速度を計算
        this.rigid2d.AddForce(direction * speed); // 力を加える
        shotGaugeSet = false; // マウス押下追跡フラグをリセット
        isShooting = true; // 発射中フラグを設定

        Debug.Log("Mouse up at: " + endPos);
        Debug.Log("Direction: " + direction);
        Debug.Log("Distance: " + distance);
        Debug.Log("Speed: " + speed);
    }

    // StopShooting関数 
    void StopShooting() // 発射を停止し、速度をゼロに設定する関数
    {
        this.rigid2d.velocity *= 0; // 発射を停止し、速度をゼロに設定
        isShooting = false; // 発射中フラグをリセット
        Debug.Log("スペースキーを押したのでリセット");
    }

    // ApplyFriction関数 
    void ApplyFriction() // 摩擦を適用して速度を徐々に減少させる関数
    {
        this.rigid2d.velocity *= 0.995f; // 摩擦を適用して速度を減少させる
    }
}
