using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    void Start()
    {
        // ボタンを探してアクティブにする
        Button yourButton = GameObject.Find("YourButtonName").GetComponent<Button>();
        if (yourButton != null)
        {
            yourButton.gameObject.SetActive(true);
        }
    }
}