using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    Rigidbody2D rigid2d;         // Rigidbody2D�̃R���|�[�l���g
    Vector2 startPos;            // �}�E�X���������Ƃ��̊J�n�ʒu���L�^����
    float speed = 0;             // ���ˑ��x��ێ�����
    bool shotGaugeSet = false;   // �}�E�X�����ꂽ���ǂ����ǐ�
    bool isShooting = false;     // �I�u�W�F�N�g���˒����ǂ���

    // Start�֐� 
    void Start() // Rigidbody2D�R���|�[�l���g���擾����֐�
    {
        this.rigid2d = GetComponent<Rigidbody2D>(); // Rigidbody2D�R���|�[�l���g���擾
    }

    // Update�֐� 
    void Update() // �e�t���[���ł̍X�V�������s���֐�
    {
        if (!isShooting)    // ���˒��łȂ��ꍇ�̂݁A�}�E�X���͂�����
        {
            HandleMouseInput(); // �}�E�X���͂���������֐�
        }
        if (Input.GetKeyDown(KeyCode.Space)) // �X�y�[�X�L�[�����Ŕ��˂��~
        {
            StopShooting(); // ���˂��~����֐�
        }
    }

    // FixedUpdate�֐� 
    void FixedUpdate() // �Œ�t���[�����[�g�ł̍X�V�������s���֐�
    {
        ApplyFriction(); // ���C��K�p���đ��x������������֐�
    }

    // HandleMouseInput�֐� 
    void HandleMouseInput() // �}�E�X�������ꂽ�ʒu���L�^���������Ƃ��ɔ��˂���֐�
    {
        if (Input.GetMouseButtonDown(0)) // �}�E�X�{�^���������ꂽ�Ƃ��̏���
        {
            RecordStartPosition(); // �J�n�ʒu���L�^����֐�
        }
        if (Input.GetMouseButtonUp(0)) // �}�E�X�{�^���������ꂽ�Ƃ��̏���
        {
            Shoot(); // ���˂���֐�
        }
    }

    // RecordStartPosition�֐� 
    void RecordStartPosition() // �J�n�ʒu���L�^����֐�
    {
        this.startPos = Input.mousePosition; // �}�E�X���������n�_�̍��W���L�^
        shotGaugeSet = true;
        Debug.Log("Mouse down at: " + startPos);
    }

    // Shoot�֐� 
    void Shoot() // �}�E�X�̈ʒu���甭�˕����Ƒ��x���v�Z���A���˂���֐�
    {
        Vector2 endPos = Input.mousePosition; // �}�E�X�𗣂����n�_�̍��W���擾
        Vector2 direction = (startPos - endPos).normalized; // ���˕������v�Z
        float distance = Vector2.Distance(startPos, endPos); // �}�E�X�̈ړ��������v�Z
        speed = distance * 2; // ���ˑ��x���v�Z
        this.rigid2d.AddForce(direction * speed); // �͂�������
        shotGaugeSet = false; // �}�E�X�����ǐՃt���O�����Z�b�g
        isShooting = true; // ���˒��t���O��ݒ�

        Debug.Log("Mouse up at: " + endPos);
        Debug.Log("Direction: " + direction);
        Debug.Log("Distance: " + distance);
        Debug.Log("Speed: " + speed);
    }

    // StopShooting�֐� 
    void StopShooting() // ���˂��~���A���x���[���ɐݒ肷��֐�
    {
        this.rigid2d.velocity *= 0; // ���˂��~���A���x���[���ɐݒ�
        isShooting = false; // ���˒��t���O�����Z�b�g
        Debug.Log("�X�y�[�X�L�[���������̂Ń��Z�b�g");
    }

    // ApplyFriction�֐� 
    void ApplyFriction() // ���C��K�p���đ��x�����X�Ɍ���������֐�
    {
        this.rigid2d.velocity *= 0.995f; // ���C��K�p���đ��x������������
    }
}
