using UnityEngine;

//rainスクリプトで複製したオブジェクトが画面外に出た場合削除する
public class raindelete : MonoBehaviour
{
    private float bottomLimit = -10.0f; // 下限

    private void Update()
    {
        if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}
