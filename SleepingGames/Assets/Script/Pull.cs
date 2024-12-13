using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    Rigidbody2D rigid2d;
    Vector2 startPos;
    float speed = 0;
    bool shotGaugeSet = false;
    bool isShooting = false;

    void Start()
    {
        this.rigid2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���˒��łȂ��ꍇ�̂݁A�}�E�X���͂��󂯕t����
        if (!isShooting)
        {
            // �}�E�X���������n�_�̍��W���L�^
            if (Input.GetMouseButtonDown(0))
            {
                this.startPos = Input.mousePosition;
                shotGaugeSet = true;
                Debug.Log("Mouse down at: " + startPos);
            }

            // �}�E�X�𗣂����n�_�̍��W����A���˕������v�Z
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 endPos = Input.mousePosition;
                Vector2 direction = (startPos - endPos).normalized;
                float distance = Vector2.Distance(startPos, endPos);  // �������v�Z
                speed = distance * 2;  // �����ɉ����ăX�s�[�h��ݒ�
                this.rigid2d.AddForce(direction * speed);
                shotGaugeSet = false;
                isShooting = true;  // ���˒��ɐݒ�
                Debug.Log("Mouse up at: " + endPos);
                Debug.Log("Direction: " + direction);
                Debug.Log("Distance: " + distance);
                Debug.Log("Speed: " + speed);
            }
        }

        // �e�X�g�p�F�X�y�[�X�L�[�����Œ�~
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2d.velocity *= 0;
            isShooting = false;  // ���˒�~
            Debug.Log("Space key pressed: Velocity set to 0");
        }
    }

    void FixedUpdate()
    {
        this.rigid2d.velocity *= 0.995f;
    }
}
