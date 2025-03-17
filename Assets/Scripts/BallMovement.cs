using UnityEngine;
using System.Collections;  // ใช้สำหรับ Coroutine

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 10f;        // ความเร็วการเคลื่อนที่
    public float jumpForce = 5f;         // แรงกระโดด
    public float jumpCooldown = 1f;      // เวลาหน่วง (Cooldown) หลังการกระโดด
    public Transform cameraTransform;    // กล้อง (Main Camera)

    private Rigidbody rb;                // Rigidbody ของลูกบอล
    private bool canJump = true;         // ตัวแปรเช็คว่ากระโดดได้หรือไม่

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        // กด Spacebar กระโดดได้ถ้า cooldown เสร็จแล้ว
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
            StartCoroutine(JumpCooldown());  // เริ่ม Coroutine เพื่อจัดการ cooldown
        }
    }

    void Move()
    {
        // รับค่าจาก Input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // เอาทิศทางกล้องมาใช้เคลื่อนที่
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // ไม่ให้ลูกบอลวิ่งขึ้นลงตามกล้อง
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // คำนวณทิศทางเคลื่อนที่
        Vector3 moveDirection = forward * v + right * h;

        // ใส่แรงให้ลูกบอล
        rb.AddForce(moveDirection * moveSpeed);
    }

    void Jump()
    {
        // เพิ่มแรงกระโดดทันที (Impulse)
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    IEnumerator JumpCooldown()
    {
        canJump = false;  // ไม่ให้กระโดดซ้ำในระหว่าง cooldown
        yield return new WaitForSeconds(jumpCooldown);  // รอเวลาตามที่กำหนด
        canJump = true;  // ให้กระโดดได้อีกครั้ง
    }
}