using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;  // 矢印のプレハブ
    public GameObject trash;  // ゴミのGameObject
    public float maxArrowLength = 5f;  // 矢印の長さの上限
    private GameObject arrowInstance;
    private Vector2 clickPosition;
    private bool arrowSpawned = false;  // 矢印が生成されたかどうかを記録するフラグ
    private bool arrowDeleted = false;  // 矢印が削除されたかどうかを記録するフラグ

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !arrowSpawned && !arrowDeleted)
        {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SpawnArrow();
            arrowSpawned = true;  // 矢印が生成されたことを記録
        }

        if (Input.GetMouseButton(0) && arrowInstance != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateArrowRotation(mousePosition);
            UpdateArrowScale(mousePosition);
        }

        if (Input.GetMouseButtonUp(0) && arrowInstance != null)
        {
            Destroy(arrowInstance);  // 矢印を消去
            arrowInstance = null;
            arrowSpawned = false; // 矢印の生成をリセット
            arrowDeleted = true;  // 矢印が消去されたことを記録
        }

        // ゴミの位置に矢印を追従させる
        if (arrowInstance != null)
        {
            arrowInstance.transform.position = trash.transform.position;
        }
    }

    void SpawnArrow()
    {
        arrowInstance = Instantiate(arrowPrefab, trash.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));  // 初期回転を修正
        arrowInstance.SetActive(true);
    }

    void UpdateArrowRotation(Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - clickPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrowInstance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));  // 回転を修正
    }

    void UpdateArrowScale(Vector2 targetPosition)
    {
        float distance = Vector2.Distance(clickPosition, targetPosition);
        distance = Mathf.Min(distance, maxArrowLength); // 距離が上限を超えないようにする
        arrowInstance.transform.localScale = new Vector3(arrowInstance.transform.localScale.x, distance, arrowInstance.transform.localScale.z);
    }
}
