using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Backmenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Button backM;

    void Start()
    {
        backM.onClick.AddListener(BackmenuM);
    }

    // Update is called once per frame
    void BackmenuM()
    {
        SceneManager.LoadScene("Menu");  // เปลี่ยนชื่อ "MainScene" เป็นชื่อของฉากหลักที่คุณต้องการให้โหลด
    }
}
