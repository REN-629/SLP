using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        // �G�f�B�^�ł͂Ȃ��r���h���ꂽ�Q�[���Ŏ��s����Ă���ꍇ�A�Q�[�����I��
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
