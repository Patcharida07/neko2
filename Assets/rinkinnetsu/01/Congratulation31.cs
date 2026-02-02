using UnityEngine;
using UnityEngine.SceneManagement;

public class Congratulation31 : MonoBehaviour
{
    // 🔁 Restart ด่าน 3 ใหม่หมด
    public void ReplayGameButtonn()
    {
        Debug.Log("Restart Level 3");

        if (GameManager.Instance != null)
            GameManager.Instance.ResetForRestartLevel();

        SceneManager.LoadScene("Level3");
    }

     //🎮 Retry Puzzle(ผู้เล่นอยู่จุดเดิม)
    public void RetryPuzzleButton()
    {
        Debug.Log("Retry Puzzle");

        if (GameManager.Instance != null)
            GameManager.Instance.ResetForRetryPuzzle();

        SceneManager.LoadScene("NewPuzzle");
    }

    // ➡️ ไปด่านถัดไป
    public void NextlevelGameButton()
    {
        Debug.Log("Next Level");

        SceneManager.LoadScene("Level4");
    }

    // 🏠 Restart ทั้งเกม (กลับ Start)
    public void returnButton()
    {
        Debug.Log("Restart Whole Game");

        if (GameManager.Instance != null)
            GameManager.Instance.ResetForNewGame();

        SceneManager.LoadScene("Start");
    }
}
