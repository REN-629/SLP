using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    void Start()
    {
        // �{�^����T���ăA�N�e�B�u�ɂ���
        Button yourButton = GameObject.Find("YourButtonName").GetComponent<Button>();
        if (yourButton != null)
        {
            yourButton.gameObject.SetActive(true);
        }
    }
}