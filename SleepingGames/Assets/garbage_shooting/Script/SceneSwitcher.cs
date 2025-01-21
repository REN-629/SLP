using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    public string SceneToLoad;  // 切り替えたいシーンの名前（Unityで名前を設定する）
    public float Delay = 0f;    // シーンを切り替えるまでの遅延時間（Unityで時間と設定する）

    //オンコリュージョンエンター2D関数
    //特定のオブジェクトに接触するとシーン移行のプログラムを実行する
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("gomi"))//gomiのTagが付いた物に当たると以下のプログラムを実行する
        {
            Debug.Log("特定のオブジェクトに接触しました。シーンを切り替えます。");
            StartCoroutine(ChangeScene());
        }
    }

    //チェンジシーン関数
    //指定した秒数が経過するとシーンが切り替わるプログラム
    private IEnumerator ChangeScene()
    {
        Debug.Log("シーン切り替えのための遅延を開始します。");
        yield return new WaitForSeconds(Delay); // 遅延時間を待機
        Debug.Log("遅延が完了しました。シーンを切り替えます。");
        SceneManager.LoadScene(SceneToLoad);    // シーンを切り替える
    }
}