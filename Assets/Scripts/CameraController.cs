using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;      // วัตถุที่กล้องจะตาม เช่น ลูกบอล
    public Vector3 offset;        // ระยะห่างจากลูกบอล
    public float mouseSensitivity = 5.0f;
    
    float rotY; // แกนแนวนอน
    float rotX; // แกนแนวตั้ง

    void Start()
    {
        offset = transform.position - target.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        rotY += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotX = Mathf.Clamp(rotX, -30f, 60f); // จำกัดการก้มเงยกล้อง

        Quaternion rotation = Quaternion.Euler(rotX, rotY, 0);
        Vector3 newPosition = target.position + rotation * offset;

        transform.position = newPosition;
        transform.LookAt(target);
    }
}