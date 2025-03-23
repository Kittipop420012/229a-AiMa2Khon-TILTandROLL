using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text timeText;  // เชื่อมกับ UI Text ใน Game Over Scene

    void Start()
{
    float finalTime = PlayerPrefs.GetFloat("FinalTime", -1); // ใช้ -1 เป็นค่าเริ่มต้น

    Debug.Log("FinalTime จาก PlayerPrefs: " + finalTime); // เช็คค่าที่ดึงมา

    if (timeText != null)
    {
        if (finalTime == -1)
            timeText.text = "Error: No Time Data"; // ถ้าไม่เจอข้อมูล
        else
            timeText.text = "Your Time: " + finalTime.ToString("F2") + "s";
    }
}
}
