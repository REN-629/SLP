using UnityEngine;
using System.Collections;

//fadeスクリプトにフェード開始前まで待機する機能を追加
public class fadetimer : MonoBehaviour
{
    public float fadeDuration = 2f; // フェードインの時間
    public float delayDuration = 1f; // フェードイン開始前の待機時間
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        StartCoroutine(DelayedFadeIn());
    }

    IEnumerator DelayedFadeIn()
    {
        yield return new WaitForSeconds(delayDuration); // 指定した秒数待機
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
