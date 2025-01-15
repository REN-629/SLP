using UnityEngine;

public class SwitchObjects : MonoBehaviour
{
    public GameObject object1; // 最初に表示されるオブジェクト
    public GameObject object2; // 消えた後に表示されるオブジェクト

    void Start()
    {
        // ゲーム開始時にobject2を非表示にする
        object2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // object1の位置を取得
            Vector3 position = object1.transform.position;

            // object1を非表示にする
            object1.SetActive(false);

            // object2をobject1の位置に移動する（向きはそのまま）
            object2.transform.position = position;
            object2.SetActive(true);

            Debug.Log("スペースキーが押されました。object2が表示されました。");
        }
    }
}
