using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;      // 矢印のプレハブ
    public GameObject trash;            // ゴミのGameObject
    public float maxArrowLength = 5f;   // 矢印の長さの上限
    private GameObject arrowInstance;   // 矢印のインスタンス
    private Vector2 clickPosition;      // クリック位置を記録するための変数
    private bool arrowSpawned = false;  // 矢印が生成されたかどうかを記録するフラグ
    private bool arrowDeleted = false;  // 矢印が削除されたかどうかを記録するフラグ

    // アップデート関数
    // 毎フレーム呼び出される関数
    // 説明：Unityのフレームごとに呼び出され、入力のチェックやオブジェクトを更新
    void Update()
    {
        // 左クリックが押されたとき、新しい矢印が生成されていなくて、矢印が削除されていない場合
        if (Input.GetMouseButtonDown(0) && !arrowSpawned && !arrowDeleted)
        {
            // クリック位置をスクリーン座標（画面上の特定のピクセル）からワールド座標（ゲームの仮想空間内の位置）に変更
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            SpawnArrow(); // 矢印を生成する

            arrowSpawned = true;  // 矢印が生成されたことを記録
        }

        // 左クリックを押し続けている間、矢印のインスタンスが存在する場合
        if (Input.GetMouseButton(0) && arrowInstance != null)
        {
            // 現在のマウス位置をワールド座標に変換
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 矢印の方向とスケール更新
            UpdateArrowRotation(mousePosition);
            UpdateArrowScale(mousePosition);

        }

        // 左クリックを離したとき、矢印のインスタンスが存在する場合
        if (Input.GetMouseButtonUp(0) && arrowInstance != null)
        {
            Destroy(arrowInstance);  // 矢印を消去
            arrowInstance = null;

            arrowSpawned = false;    // 矢印の生成をリセット
            arrowDeleted = true;     // 矢印が消去されたことを記録
        }

        // ゴミの位置に矢印を追従させる
        if (arrowInstance != null)
        {
            arrowInstance.transform.position = trash.transform.position;
        }
    }

    // スパウンアロー関数
    // 矢印の生成
    // 説明：矢印のプレハブをインスタンス化し、指定位置に配置する
    void SpawnArrow()
    {
        // 矢印のインスタンスを生成し、初期回転を設定
        arrowInstance = Instantiate(arrowPrefab, trash.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));  // 初期回転を修正
        arrowInstance.SetActive(true);
    }

    // アップデートアローローテーション関数
    // 矢印の回転を更新
    // 説明：この関数は矢印の方向をクリック位置と現在のマウス位置の間の角度に基づいて調整
    void UpdateArrowRotation(Vector2 targetPosition)
    {
        // クリック位置と現在のマウス位置との方向ベクトルを計算
        Vector2 direction = targetPosition - clickPosition;

        // 方向ベクトルから角度を計算（ラジアンを度に変換）
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 矢印の回転を設定（90度補正）
        arrowInstance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));  // 回転を修正

    }

    // アップデートアロースケール関数
    // 矢印の長さを更新
    // 説明：この関数はクリック位置からマウス位置までの距離に基づいて矢印の長さを調整
    void UpdateArrowScale(Vector2 targetPosition)
    {
        // クリック位置からマウス位置までの距離を計算
        float distance = Vector2.Distance(clickPosition, targetPosition);

        // 距離を上限の長さに制限
        distance = Mathf.Min(distance, maxArrowLength);

        // 矢印のスケールを更新
        arrowInstance.transform.localScale = new Vector3(arrowInstance.transform.localScale.x, distance, arrowInstance.transform.localScale.z);
    }
}