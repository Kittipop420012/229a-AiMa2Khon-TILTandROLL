using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button quitButton;

    void Start()
    {
        quitButton.onClick.AddListener(QuitApplication);
    }

    void QuitApplication()
    {
        Debug.Log("Game is quitting..."); // แสดงข้อความใน Console (ใช้ได้เฉพาะใน Editor)
        Application.Quit(); // ใช้ออกจากเกมจริงๆ (จะทำงานเมื่อ Build เกมแล้ว)
    }
}