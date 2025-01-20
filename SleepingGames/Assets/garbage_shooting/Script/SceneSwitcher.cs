using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad;  // 切り替えたいシーンの名前（Unityで名前を設定する）
    public float delay = 0f;    // シーンを切り替えるまでの遅延時間（Unityで時間と設定する）

    //
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("gomi"))//このスプリクトが付いたオブジェクトがゴミ箱に入った時に以下のプログラムを実行する
        {
            Debug.Log("特定のオブジェクトに接触しました。シーンを切り替えます。");
            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    //指定した秒数が経過するとシーンが切り替わるプログラム
    private IEnumerator ChangeSceneAfterDelay()
    {
        Debug.Log("シーン切り替えのための遅延を開始します。");
        yield return new WaitForSeconds(delay); // 遅延時間を待機
        Debug.Log("遅延が完了しました。シーンを切り替えます。");
        SceneManager.LoadScene(sceneToLoad);    // シーンを切り替える
    }
}
