using UnityEngine;

public class ExitButton2D : MonoBehaviour
{
    public void ExitGame()
    {
        // エディタでの動作確認用
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ビルド後のゲーム終了
        Application.Quit();
#endif
    }
}
