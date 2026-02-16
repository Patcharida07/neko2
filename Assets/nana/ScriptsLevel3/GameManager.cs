using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool puzzleCompleted = false;

    public Vector3 lastRealPos;
    public Vector3 lastShadowPos;
    public bool hasSavedPos = false;
    public bool comingFromPuzzle = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetForRestartLevel()
    {
        puzzleCompleted = false;
        hasSavedPos = false;
        comingFromPuzzle = false;
        lastRealPos = Vector3.zero;
        lastShadowPos = Vector3.zero;
    }

    public void ResetForRetryPuzzle()
    {
        puzzleCompleted = false;
        // ยังเก็บตำแหน่ง
    }

    public void ResetForNewGame()
    {
        puzzleCompleted = false;
        hasSavedPos = false;
        comingFromPuzzle = false;
        lastRealPos = Vector3.zero;
        lastShadowPos = Vector3.zero;
    }
}