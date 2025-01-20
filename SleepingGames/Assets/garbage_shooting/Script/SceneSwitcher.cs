using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad;  // �؂�ւ������V�[���̖��O�iUnity�Ŗ��O��ݒ肷��j
    public float delay = 0f;    // �V�[����؂�ւ���܂ł̒x�����ԁiUnity�Ŏ��ԂƐݒ肷��j

    //
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("gomi"))//���̃X�v���N�g���t�����I�u�W�F�N�g���S�~���ɓ��������Ɉȉ��̃v���O���������s����
        {
            Debug.Log("����̃I�u�W�F�N�g�ɐڐG���܂����B�V�[����؂�ւ��܂��B");
            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    //�w�肵���b�����o�߂���ƃV�[�����؂�ւ��v���O����
    private IEnumerator ChangeSceneAfterDelay()
    {
        Debug.Log("�V�[���؂�ւ��̂��߂̒x�����J�n���܂��B");
        yield return new WaitForSeconds(delay); // �x�����Ԃ�ҋ@
        Debug.Log("�x�����������܂����B�V�[����؂�ւ��܂��B");
        SceneManager.LoadScene(sceneToLoad);    // �V�[����؂�ւ���
    }
}
