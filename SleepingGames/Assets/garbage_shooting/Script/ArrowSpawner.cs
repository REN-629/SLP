using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;  // ���̃v���n�u
    public GameObject trash;  // �S�~��GameObject
    public float maxArrowLength = 5f;  // ���̒����̏��
    private GameObject arrowInstance;
    private Vector2 clickPosition;
    private bool arrowSpawned = false;  // ��󂪐������ꂽ���ǂ������L�^����t���O
    private bool arrowDeleted = false;  // ��󂪍폜���ꂽ���ǂ������L�^����t���O

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !arrowSpawned && !arrowDeleted)
        {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SpawnArrow();
            arrowSpawned = true;  // ��󂪐������ꂽ���Ƃ��L�^
        }

        if (Input.GetMouseButton(0) && arrowInstance != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateArrowRotation(mousePosition);
            UpdateArrowScale(mousePosition);
        }

        if (Input.GetMouseButtonUp(0) && arrowInstance != null)
        {
            Destroy(arrowInstance);  // ��������
            arrowInstance = null;
            arrowSpawned = false; // ���̐��������Z�b�g
            arrowDeleted = true;  // ��󂪏������ꂽ���Ƃ��L�^
        }

        // �S�~�̈ʒu�ɖ���Ǐ]������
        if (arrowInstance != null)
        {
            arrowInstance.transform.position = trash.transform.position;
        }
    }

    void SpawnArrow()
    {
        arrowInstance = Instantiate(arrowPrefab, trash.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));  // ������]���C��
        arrowInstance.SetActive(true);
    }

    void UpdateArrowRotation(Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - clickPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrowInstance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));  // ��]���C��
    }

    void UpdateArrowScale(Vector2 targetPosition)
    {
        float distance = Vector2.Distance(clickPosition, targetPosition);
        distance = Mathf.Min(distance, maxArrowLength); // ����������𒴂��Ȃ��悤�ɂ���
        arrowInstance.transform.localScale = new Vector3(arrowInstance.transform.localScale.x, distance, arrowInstance.transform.localScale.z);
    }
}
