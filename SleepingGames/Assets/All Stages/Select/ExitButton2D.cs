using UnityEngine;

public class ExitButton2D : MonoBehaviour
{
    public void ExitGame()
    {
        // �G�f�B�^�ł̓���m�F�p
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // �r���h��̃Q�[���I��
        Application.Quit();
#endif
    }
}
