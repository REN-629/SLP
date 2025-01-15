using UnityEngine;
using System.Collections;

public class TrashDisappearAndFire : MonoBehaviour
{
    public GameObject firePrefab; // �΂̃v���n�u
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

        Destroy(gameObject); // �S�~������

        for (int i = 0; i < 5; i++)
        {
            GameObject fire = Instantiate(firePrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(2f); // 2�b�҂�
            Destroy(fire); // �΂̃G�t�F�N�g������
        }
    }
}
