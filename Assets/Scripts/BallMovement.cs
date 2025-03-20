using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // สำหรับโหลด Scene ใหม่

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    public float jumpCooldown = 1f;
    public Transform cameraTransform;

    private Rigidbody rb;
    private bool canJump = true;

    private int totalTargets = 5;         // จำนวนวัตถุเป้าหมาย (แก้เป็น 5)
    private int currentHits = 0;
    private bool[] hitFlags;

    public Text messageText;

    private bool isGameOver = false;      // เพิ่มตัวแปรเช็คว่าเกมจบหรือยัง

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        hitFlags = new bool[totalTargets];

        if (messageText != null)
            messageText.text = ""; // เริ่มต้นข้อความว่าง

        // ล็อกเมาส์ตอนเริ่ม
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (isGameOver)
        {
            // ถ้าเกมจบแล้วไม่ให้ทำอะไรต่อ
            return;
        }

        Move();

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
            StartCoroutine(JumpCooldown());
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
    }
}
