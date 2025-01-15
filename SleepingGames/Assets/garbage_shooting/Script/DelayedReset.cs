using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // これが必要です

public class DelayedReset : MonoBehaviour
{
    public float resetDelay = 3.0f; // リセットまでの遅延時間（秒）
    private bool isResetting = false; // リセット中かどうかのフラグ

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isResetting)
        {
            StartCoroutine(ResetAfterDelay());
        }
    }

    IEnumerator ResetAfterDelay() // こちらがエラーの原因となる場合があります
    {
        isResetting = true;
        yield return new WaitForSeconds(resetDelay); // 遅延時間の待機
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 現在のシーンをリロード
        isResetting = false;
    }
}
