using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pull : MonoBehaviour
{
    // 2D���W�b�g�{�f�B
    Rigidbody2D rigid2d;
    // �}�E�X���������Ƃ��̊J�n�ʒu���L�^����
    Vector2 startPos;
    // ���ˑ��x��ێ�����
    float speed = 0;
    // �}�E�X�����ꂽ���ǂ����ǐ�
    bool shotGaugeSet = false;
    // �I�u�W�F�N�g���˒����ǂ���
    bool isShooting = false;
    void Start()
    {
        // Rigidbody2D�R���|�[�l���g���擾
        this.rigid2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���˒��łȂ��ꍇ�̂݁A�}�E�X���͂�����
        if (!isShooting)
        {
            HandleMouseInput();
        }
        // �X�y�[�X�L�[�����Ŕ��˂��~
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopShooting();
        }
    }

    void FixedUpdate()
    {
        // ���C��K�p���đ��x������������
        ApplyFriction();
    }
    void HandleMouseInput()
    {
        // �}�E�X�{�^���������ꂽ�Ƃ��̏���
        if (Input.GetMouseButtonDown(0))
        {
            RecordStartPosition();
        }
        // �}�E�X�{�^���������ꂽ�Ƃ��̏���
        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
    }
    void RecordStartPosition()
    {
        // �}�E�X���������n�_�̍��W���L�^
        this.startPos = Input.mousePosition;
        shotGaugeSet = true;
        Debug.Log("Mouse down at: " + startPos);
    }
    void Shoot()
    {
        // �}�E�X�𗣂����n�_�̍��W���甭�˕����Ƒ��x���v�Z���A�͂�������
        Vector2 endPos = Input.mousePosition;
        Vector2 direction = (startPos - endPos).normalized;

        float distance = Vector2.Distance(startPos, endPos);
        speed = distance * 2;

        this.rigid2d.AddForce(direction * speed);

        shotGaugeSet = false;
        isShooting = true;

        Debug.Log("Mouse up at: " + endPos);
        Debug.Log("Direction: " + direction);
        Debug.Log("Distance: " + distance);
        Debug.Log("Speed: " + speed);
    }

    void StopShooting()
    {
        // ���˂��~���A���x���[���ɐݒ�
        this.rigid2d.velocity *= 0;
        isShooting = false;
        Debug.Log("Space key pressed: Velocity set to 0");
    }
    void ApplyFriction()
    {
        // ���C��K�p���đ��x�����X�Ɍ���������
        this.rigid2d.velocity *= 0.995f;
    }
}
