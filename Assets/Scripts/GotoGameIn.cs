using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GotoGameIn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Button Gamein;

    void Start()
    {
        Gamein.onClick.AddListener(Gotogame);
    }

    // Update is called once per frame
    void Gotogame()
    {
        SceneManager.LoadScene("Game");  // เปลี่ยนชื่อ "MainScene" เป็นชื่อของฉากหลักที่คุณต้องการให้โหลด
    }
}
