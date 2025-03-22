using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 10f; // ปรับความเร็วการหมุน

    void FixedUpdate()
    {
    transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime, Space.Self);
    }
}