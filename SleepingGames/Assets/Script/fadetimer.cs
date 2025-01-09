using UnityEngine;
using System.Collections;

public class fadetimer : MonoBehaviour
{
    public float fadeDuration = 2f; // �t�F�[�h�C���̎���
    public float delayDuration = 1f; // �t�F�[�h�C���J�n�O�̑ҋ@����
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        StartCoroutine(DelayedFadeIn());
    }

    IEnumerator DelayedFadeIn()
    {
        yield return new WaitForSeconds(delayDuration); // �w�肵���b���ҋ@
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }
}
