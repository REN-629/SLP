using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    public string SceneToLoad;  // �؂�ւ������V�[���̖��O�iUnity�Ŗ��O��ݒ肷��j
    public float Delay = 0f;    // �V�[����؂�ւ���܂ł̒x�����ԁiUnity�Ŏ��ԂƐݒ肷��j

    //OnCollisionEnter2D�֐�
    //����̃I�u�W�F�N�g�ɐڐG����ƃV�[���ڍs�̃v���O���������s����
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("gomi"))//gomi��Tag���t�������ɓ�����ƈȉ��̃v���O���������s����
        {
            Debug.Log("����̃I�u�W�F�N�g�ɐڐG���܂����B�V�[����؂�ւ��܂��B");
            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    //ChangeSceneAfterDelay�֐�
    //�w�肵���b�����o�߂���ƃV�[�����؂�ւ��v���O����
    private IEnumerator ChangeSceneAfterDelay()
    {
        Debug.Log("�V�[���؂�ւ��̂��߂̒x�����J�n���܂��B");
        yield return new WaitForSeconds(Delay); // �x�����Ԃ�ҋ@
        Debug.Log("�x�����������܂����B�V�[����؂�ւ��܂��B");
        SceneManager.LoadScene(SceneToLoad);    // �V�[����؂�ւ���
    }
}