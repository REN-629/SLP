using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timerText; // タイマー表示用のUIテキスト
    private static float timeElapsed; // 静的変数として経過時間を保持

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
