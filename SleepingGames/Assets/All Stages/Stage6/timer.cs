using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timerText; // �^�C�}�[�\���p��UI�e�L�X�g
    private static float timeElapsed; // �ÓI�ϐ��Ƃ��Čo�ߎ��Ԃ�ێ�

    void Update()
    {
        timeElapsed += Time.deltaTime;
        timerText.text = "Time: " + timeElapsed.ToString("F2") + "s";
    }

    public static float GetTimeElapsed()
    {
        return timeElapsed;
    }
}
