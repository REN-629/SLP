using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // ここを確認してください

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad; // 切り替えたいシーンの名前
    private bool isTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTriggered) // 複数回呼ばれないようにする
        {
            isTriggered = true;
            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    private IEnumerator ChangeSceneAfterDelay() // ここを確認してください
    {
        yield return new WaitForSeconds(3f); // 3秒待機
        SceneManager.LoadScene(sceneToLoad); // シーンを切り替える
    }
}
