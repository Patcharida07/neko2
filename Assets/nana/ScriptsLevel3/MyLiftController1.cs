using UnityEngine;
using UnityEngine.SceneManagement;

public class MyLiftController1 : MonoBehaviour
{
    [Header("ตั้งค่า Elevator")]
    public float speed = 2f;
    public float stopY = 5f;
    public string nextSceneName;

    private bool isMoving = false;
    public bool playerOnLift = false;//ตัวตรวจ Player บนลิฟต์

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);

            if (transform.position.y >= stopY)
            {
                isMoving = false;
                Debug.Log("🏁 Elevator reached stopY");
                LoadNextScene();
            }
        }
    }

    // ฟังก์ชันให้สวิตช์เรียก
    public void ActivateLift()
    {
        if (!isMoving)
        {
            isMoving = true;
            Debug.Log("▶ Elevator activated!");
        }
    }

    // ⭐ ตรวจว่าผู้เล่นขึ้นลิฟต์
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnLift = true;
            Debug.Log("🧍 Player on lift");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnLift = false;
            Debug.Log("🧍 Player left lift");
        }
    }


    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log($"🌐 Loading scene: {nextSceneName}");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}