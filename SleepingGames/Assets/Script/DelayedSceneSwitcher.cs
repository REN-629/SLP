using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DelayedSceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; // 切り替えたいシーンの名前
    public float delay = 3f; // シーンを切り替えるまでの遅延時間（秒）

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("gomi"))
        {
            Debug.Log("特定のオブジェクトに接触しました。シーンを切り替えます。");
            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        Debug.Log("シーン切り替えのための遅延を開始します。");
        yield return new WaitForSeconds(delay); // 遅延時間を待機
        Debug.Log("遅延が完了しました。シーンを切り替えます。");
        SceneManager.LoadScene(sceneToLoad); // シーンを切り替える
    }
}
