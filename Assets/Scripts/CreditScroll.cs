using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditScroll : MonoBehaviour
{
    public float scrollSpeed = 50f;

    void Start()
    {
        // ให้รอ 10 วินาที แล้วเปลี่ยนฉาก
        Invoke("LoadNextScene", 40f);
    }
    void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("NextScene"); // เปลี่ยนชื่อเป็นชื่อฉากที่ต้องการ
    }
}
