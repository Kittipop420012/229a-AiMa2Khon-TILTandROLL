using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Howtoplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Button howtoplay;

    void Start()
    {
        howtoplay.onClick.AddListener(howtoplayI);
    }

    // Update is called once per frame
    void howtoplayI()
    {
        SceneManager.LoadScene("HowToPlay");  // เปลี่ยนชื่อ "MainScene" เป็นชื่อของฉากหลักที่คุณต้องการให้โหลด
    }
}
