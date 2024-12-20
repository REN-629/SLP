using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        // エディタではなくビルドされたゲームで実行されている場合、ゲームを終了
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
