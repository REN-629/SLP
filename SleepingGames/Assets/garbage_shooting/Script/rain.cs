using UnityEngine;
using System.Collections;

public class rain : MonoBehaviour
{
    public GameObject rainPrefab; // ここにPrefabを指定します
    public float spawnInterval = 0.5f; // 生成間隔（秒）
    public float initialDelay = 15.0f; // 初期遅延（秒）
    public float spawnRangeX = 5.0f; // 生成範囲（X軸）
    public float randomSpeedMin = -1.0f; // 横方向速度の最小値
    public float randomSpeedMax = 1.0f; // 横方向速度の最大値

    private void Start()
    {
        Debug.Log("Starting Coroutine"); // デバッグログを追加
        StartCoroutine(SpawnRain());
    }

    private IEnumerator SpawnRain()
    {
        Debug.Log("Initial Delay Start"); // デバッグログを追加
        yield return new WaitForSeconds(initialDelay);
        Debug.Log("Initial Delay End"); // デバッグログを追加

        while (true)
        {
            float spawnPositionX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPosition = new Vector3(spawnPositionX, transform.position.y, 0);
            Debug.Log("Spawn Position: " + spawnPosition); // スポーン位置をログに表示

            // プレハブが存在するかを確認してからインスタンス化する
            if (rainPrefab != null)
            {
                GameObject rainDrop = Instantiate(rainPrefab, spawnPosition, Quaternion.identity);

                // ランダムな横方向の速度を付与する
                float randomSpeed = Random.Range(randomSpeedMin, randomSpeedMax);
                Rigidbody2D rb = rainDrop.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = new Vector2(randomSpeed, rb.velocity.y);
                }

                Debug.Log("Spawning Rain with speed: " + randomSpeed); // デバッグログを追加
            }
            else
            {
                Debug.Log("Rain Prefab is null"); // デバッグログを追加
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
