using UnityEngine;
using System.Collections;

public class rain : MonoBehaviour
{
    public GameObject rainPrefab; // ������Prefab���w�肵�܂�
    public float spawnInterval = 0.5f; // �����Ԋu�i�b�j
    public float initialDelay = 15.0f; // �����x���i�b�j
    public float spawnRangeX = 5.0f; // �����͈́iX���j
    public float randomSpeedMin = -1.0f; // ���������x�̍ŏ��l
    public float randomSpeedMax = 1.0f; // ���������x�̍ő�l

    private void Start()
    {
        Debug.Log("Starting Coroutine"); // �f�o�b�O���O��ǉ�
        StartCoroutine(SpawnRain());
    }

    private IEnumerator SpawnRain()
    {
        Debug.Log("Initial Delay Start"); // �f�o�b�O���O��ǉ�
        yield return new WaitForSeconds(initialDelay);
        Debug.Log("Initial Delay End"); // �f�o�b�O���O��ǉ�

        while (true)
        {
            float spawnPositionX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPosition = new Vector3(spawnPositionX, transform.position.y, 0);
            Debug.Log("Spawn Position: " + spawnPosition); // �X�|�[���ʒu�����O�ɕ\��

            // �v���n�u�����݂��邩���m�F���Ă���C���X�^���X������
            if (rainPrefab != null)
            {
                GameObject rainDrop = Instantiate(rainPrefab, spawnPosition, Quaternion.identity);

                // �����_���ȉ������̑��x��t�^����
                float randomSpeed = Random.Range(randomSpeedMin, randomSpeedMax);
                Rigidbody2D rb = rainDrop.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = new Vector2(randomSpeed, rb.velocity.y);
                }

                Debug.Log("Spawning Rain with speed: " + randomSpeed); // �f�o�b�O���O��ǉ�
            }
            else
            {
                Debug.Log("Rain Prefab is null"); // �f�o�b�O���O��ǉ�
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
