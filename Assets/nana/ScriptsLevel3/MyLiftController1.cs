using UnityEngine;
using UnityEngine.SceneManagement;

public class MyLiftController1 : MonoBehaviour
{
    public float speed = 2f;
    public float stopY = 5f;
    public string nextSceneName;

    private bool isMoving = false;
    public bool playerOnLift = false;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);

            if (transform.position.y >= stopY)
            {
                isMoving = false;
                LoadNextScene();
            }
        }
    }

    public void ActivateLift()
    {
        if (!isMoving)
            isMoving = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Shadow"))
            playerOnLift = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Shadow"))
            playerOnLift = false;
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.hasSavedPos = false;
                GameManager.Instance.comingFromPuzzle = false;
            }
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
