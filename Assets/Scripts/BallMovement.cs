using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    public float jumpCooldown = 1f;
    public Transform cameraTransform;

    private Rigidbody rb;
    private bool canJump = true;

    private int totalTargets = 5;         
    private int currentHits = 0;          
    private bool[] hitFlags;

    public Text messageText;  
    public Text scoreText;    

    private float timer = 0f;   
    public Text timerText;      
    private bool isGameActive = true;  
    private bool isGameOver = false;      

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        hitFlags = new bool[totalTargets];

        if (messageText != null)
            messageText.text = ""; // เริ่มต้นข้อความว่าง

        if (scoreText != null)
            scoreText.text = "0/" + totalTargets; // ตั้งค่าเริ่มต้นเป็น "0/5"

        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (isGameOver)
        {
            
            return;
        }

        Move();

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
            StartCoroutine(JumpCooldown());
        }

        if (isGameActive)
        {
            timer += Time.deltaTime; // เพิ่มเวลาตามเวลาที่ผ่านไป
             if (timerText != null)
                {
                timerText.text = "Time: " + timer.ToString("F2") + "s"; // แสดงเวลาใน UI
                }
        }   
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * v + right * h;

        rb.AddForce(moveDirection * moveSpeed);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    IEnumerator JumpCooldown()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isGameOver)
            return;

        for (int i = 0; i < totalTargets; i++)
        {
            string targetTag = "Target" + (i + 1);

            if (collision.gameObject.CompareTag(targetTag))
            {
                if (!hitFlags[i])
                {
                    hitFlags[i] = true;
                    currentHits++;

                    Debug.Log("ชน " + targetTag + " แล้ว!");

                    // ทำลาย target เมื่อชน
                    Destroy(collision.gameObject);

                    if (messageText != null)
                    messageText.text = "0/5";

                    // อัปเดตข้อความบน UI เพื่อแสดงจำนวนที่ชนแล้ว
                    if (scoreText != null)
                        scoreText.fontSize = 80;
                        scoreText.text = currentHits + "/" + totalTargets;

                    if (currentHits == totalTargets)
                    {
                        Debug.Log("ชนครบ 5 อันแล้ว!");
                        GameOver();
                    }
                }
            }
        }
    }




    void GameOver()
    { 

        isGameOver = true;

        // ปลดล็อกเมาส์
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isGameActive = false; 

        PlayerPrefs.SetFloat("FinalTime", timer);
        PlayerPrefs.Save();
        
        Debug.Log("เวลาที่ใช้: " + timer.ToString("F2") + " วินาที");

        // โหลดฉาก GameOverScene โดยอัตโนมัติ
        SceneManager.LoadScene("GameOverScene");  // เปลี่ยนชื่อฉากเป็นชื่อของหน้า Game Over
    }
}
