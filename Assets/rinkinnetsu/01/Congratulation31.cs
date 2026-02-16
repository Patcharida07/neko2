using UnityEngine;
using UnityEngine.SceneManagement;

public class Congratulation31 : MonoBehaviour
{
    public void ReplayGameButtonn()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.ResetForRestartLevel();
        SceneManager.LoadScene("Level3");
    }

    public void RetryPuzzleButton()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetForRetryPuzzle();

            GameManager.Instance.hasSavedPos = true;
            GameManager.Instance.comingFromPuzzle = true;

            GameObject real = GameObject.FindWithTag("Player");
            GameObject shadow = GameObject.FindWithTag("Shadow");
            if (real != null && shadow != null)
            {
                GameManager.Instance.lastRealPos = real.transform.position;
                GameManager.Instance.lastShadowPos = shadow.transform.position;
            }
        }
        SceneManager.LoadScene("NewPuzzle");
    }

    public void NextlevelGameButton()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.hasSavedPos = false;
            GameManager.Instance.comingFromPuzzle = false;
        }
        SceneManager.LoadScene("Level4");
    }

    public void returnButton()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.ResetForNewGame();
        SceneManager.LoadScene("Start");
    }
}