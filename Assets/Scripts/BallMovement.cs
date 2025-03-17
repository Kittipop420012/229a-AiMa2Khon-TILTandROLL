using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 300f; // ปรับค่าความแรงในการกระโดด
    public Transform cameraTransform;

    private Rigidbody rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * vertical + right * horizontal).normalized;

        rb.AddForce(moveDirection * moveSpeed);
    }

    void Jump()
    {
        // ถ้ากด Space และติดพื้นอยู่
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false; // กันกดกระโดดรัว ๆ ตอนอยู่ในอากาศ
        }
    }

    // เช็คการชนกับพื้น
    private void OnCollisionEnter(Collision collision)
    {
        // เช็คว่าชนกับพื้น (หรือสิ่งที่นับว่าเป็นพื้น)
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}