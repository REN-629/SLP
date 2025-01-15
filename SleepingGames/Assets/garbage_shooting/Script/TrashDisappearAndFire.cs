using UnityEngine;
using System.Collections;

public class TrashDisappearAndFire : MonoBehaviour
{
    public GameObject firePrefab; // 火のプレハブ
    private bool isDestroyed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDestroyed)
        {
            isDestroyed = true;
            StartCoroutine(SpawnFireInStages());
        }
    }

    private IEnumerator SpawnFireInStages()
    {
        Vector3 spawnPosition = transform.position;

        Destroy(gameObject); // ゴミを消す

        for (int i = 0; i < 5; i++)
        {
            GameObject fire = Instantiate(firePrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(2f); // 2秒待つ
            Destroy(fire); // 火のエフェクトを消す
        }
    }
}
