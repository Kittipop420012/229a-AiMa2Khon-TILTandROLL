using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;           // ลูกบอลหรือตัวละครที่กล้องจะตาม
    public float mouseSensitivity = 5.0f;
    public float minDistance = 1.5f;   // ระยะใกล้สุดที่กล้องจะเข้าไป
    public float maxDistance = 7.0f;   // ระยะไกลสุดที่กล้องจะถอยออก
    public float zoomSpeed = 2.0f;     // ความเร็วในการซูม
    public float smoothSpeed = 10.0f;  // ความเร็วในการปรับตำแหน่งกล้อง
    public LayerMask collisionMask;    // Layer ที่ใช้ตรวจสอบการชน

    private float targetDistance;
    private float currentDistance;
    private float rotY;
    private float rotX;

    void Start()
    {
        targetDistance = maxDistance;
        currentDistance = targetDistance;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // รับค่าหมุนกล้องจากเมาส์
        rotY += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotX = Mathf.Clamp(rotX, -30f, 60f);

        // รับค่าซูมจาก ScrollWheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        targetDistance -= scroll * zoomSpeed;
        targetDistance = Mathf.Clamp(targetDistance, minDistance, maxDistance);

        // คำนวณตำแหน่งที่ต้องการของกล้อง
        Quaternion rotation = Quaternion.Euler(rotX, rotY, 0);
        Vector3 direction = rotation * Vector3.back;
        Vector3 desiredCameraPos = target.position + direction * targetDistance;

        // ตรวจสอบการชน
        RaycastHit hit;
        if (Physics.Raycast(target.position, direction, out hit, targetDistance, collisionMask))
        {
            targetDistance = Mathf.Clamp(hit.distance - 0.2f, minDistance, maxDistance);
        }

        // ทำให้ระยะกล้องปรับสมูท
        currentDistance = Mathf.Lerp(currentDistance, targetDistance, Time.deltaTime * smoothSpeed);
        desiredCameraPos = target.position + direction * currentDistance;

        // อัปเดตตำแหน่งกล้องโดยไม่ให้กล้องหน่วงตามลูกบอลมากเกินไป
        transform.position = desiredCameraPos;
        transform.LookAt(target);
    }
}
