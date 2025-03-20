using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Button restartButton; // ปุ่ม Restart
    public Button mainMenuButton; // ปุ่ม Main Menu

    void Start()
    {
        // ตั้งค่า listener สำหรับปุ่ม Restart
        restartButton.onClick.AddListener(RestartGame);
        // ตั้งค่า listener สำหรับปุ่ม Main Menu
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    // ฟังก์ชันเพื่อเริ่มเกมใหม่ (โหลดหน้าเกมหลัก)
    void RestartGame()
    {
        SceneManager.LoadScene("Game");  // เปลี่ยนชื่อ "MainScene" เป็นชื่อของฉากหลักที่คุณต้องการให้โหลด
    }

    // ฟังก์ชันเพื่อกลับไปยังหน้า Main Menu
    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");  // เปลี่ยนชื่อ "MainMenuScene" เป็นชื่อของหน้า Main Menu ของคุณ
    }
}