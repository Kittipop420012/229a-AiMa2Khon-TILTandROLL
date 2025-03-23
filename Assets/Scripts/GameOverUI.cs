using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Button restartButton; // ปุ่ม Restart

    void Start()
    {
        // ตั้งค่า listener สำหรับปุ่ม Restart
        restartButton.onClick.AddListener(RestartGame);
        // ตั้งค่า listener สำหรับปุ่ม Main Menu
        
    }

    // ฟังก์ชันเพื่อเริ่มเกมใหม่ (โหลดหน้าเกมหลัก)
    void RestartGame()
    {
        SceneManager.LoadScene("Game");  // เปลี่ยนชื่อ "MainScene" เป็นชื่อของฉากหลักที่คุณต้องการให้โหลด
    }

}