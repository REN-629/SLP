using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;      // ���̃v���n�u
    public GameObject trash;            // �S�~��GameObject
    public float maxArrowLength = 5f;   // ���̒����̏��
    private GameObject arrowInstance;   // ���̃C���X�^���X
    private Vector2 clickPosition;      // �N���b�N�ʒu���L�^���邽�߂̕ϐ�
    private bool arrowSpawned = false;  // ��󂪐������ꂽ���ǂ������L�^����t���O
    private bool arrowDeleted = false;  // ��󂪍폜���ꂽ���ǂ������L�^����t���O

    // �A�b�v�f�[�g�֐�
    // ���t���[���Ăяo�����֐�
    // �����FUnity�̃t���[�����ƂɌĂяo����A���͂̃`�F�b�N��I�u�W�F�N�g���X�V
    void Update()
    {
        // ���N���b�N�������ꂽ�Ƃ��A�V������󂪐�������Ă��Ȃ��āA��󂪍폜����Ă��Ȃ��ꍇ
        if (Input.GetMouseButtonDown(0) && !arrowSpawned && !arrowDeleted)
        {
            // �N���b�N�ʒu���X�N���[�����W�i��ʏ�̓���̃s�N�Z���j���烏�[���h���W�i�Q�[���̉��z��ԓ��̈ʒu�j�ɕύX
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            SpawnArrow(); // ���𐶐�����

            arrowSpawned = true;  // ��󂪐������ꂽ���Ƃ��L�^
        }

        // ���N���b�N�����������Ă���ԁA���̃C���X�^���X�����݂���ꍇ
        if (Input.GetMouseButton(0) && arrowInstance != null)
        {
            // ���݂̃}�E�X�ʒu�����[���h���W�ɕϊ�
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ���̕����ƃX�P�[���X�V
            UpdateArrowRotation(mousePosition);
            UpdateArrowScale(mousePosition);

        }

        // ���N���b�N�𗣂����Ƃ��A���̃C���X�^���X�����݂���ꍇ
        if (Input.GetMouseButtonUp(0) && arrowInstance != null)
        {
            Destroy(arrowInstance);  // ��������
            arrowInstance = null;

            arrowSpawned = false;    // ���̐��������Z�b�g
            arrowDeleted = true;     // ��󂪏������ꂽ���Ƃ��L�^
        }

        // �S�~�̈ʒu�ɖ���Ǐ]������
        if (arrowInstance != null)
        {
            arrowInstance.transform.position = trash.transform.position;
        }
    }

    // �X�p�E���A���[�֐�
    // ���̐���
    // �����F���̃v���n�u���C���X�^���X�����A�w��ʒu�ɔz�u����
    void SpawnArrow()
    {
        // ���̃C���X�^���X�𐶐����A������]��ݒ�
        arrowInstance = Instantiate(arrowPrefab, trash.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));  // ������]���C��
        arrowInstance.SetActive(true);
    }

    // �A�b�v�f�[�g�A���[���[�e�[�V�����֐�
    // ���̉�]���X�V
    // �����F���̊֐��͖��̕������N���b�N�ʒu�ƌ��݂̃}�E�X�ʒu�̊Ԃ̊p�x�Ɋ�Â��Ē���
    void UpdateArrowRotation(Vector2 targetPosition)
    {
        // �N���b�N�ʒu�ƌ��݂̃}�E�X�ʒu�Ƃ̕����x�N�g�����v�Z
        Vector2 direction = targetPosition - clickPosition;

        // �����x�N�g������p�x���v�Z�i���W�A����x�ɕϊ��j
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ���̉�]��ݒ�i90�x�␳�j
        arrowInstance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));  // ��]���C��

    }

    // �A�b�v�f�[�g�A���[�X�P�[���֐�
    // ���̒������X�V
    // �����F���̊֐��̓N���b�N�ʒu����}�E�X�ʒu�܂ł̋����Ɋ�Â��Ė��̒����𒲐�
    void UpdateArrowScale(Vector2 targetPosition)
    {
        // �N���b�N�ʒu����}�E�X�ʒu�܂ł̋������v�Z
        float distance = Vector2.Distance(clickPosition, targetPosition);

        // ����������̒����ɐ���
        distance = Mathf.Min(distance, maxArrowLength);

        // ���̃X�P�[�����X�V
        arrowInstance.transform.localScale = new Vector3(arrowInstance.transform.localScale.x, distance, arrowInstance.transform.localScale.z);
    }
}