using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // เก็บสถานะ puzzle
    public bool puzzleCompleted = false;

    // เก็บตำแหน่งผู้เล่นล่าสุด
    public Vector3 lastRealPos;
    public Vector3 lastShadowPos;
    public bool hasSavedPos = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ✅ อยู่ข้าม Scene ได้
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetGameState()
    {
        puzzleCompleted = false;
        hasSavedPos = false;
        lastRealPos = Vector3.zero;
        lastShadowPos = Vector3.zero;
    }

    public void ResetForRestartLevel()
    {
        // รีเซตทั้งด่าน
        puzzleCompleted = false;
        hasSavedPos = false;
        lastRealPos = Vector3.zero;
        lastShadowPos = Vector3.zero;
    }

    public void ResetForRetryPuzzle()
    {
        // รีเซตเฉพาะ puzzle
        puzzleCompleted = false;
        // ยังเก็บตำแหน่งผู้เล่นไว้
    }

    public void ResetForNewGame()
    {
        // รีเซตทั้งเกม
        puzzleCompleted = false;
        hasSavedPos = false;
        lastRealPos = Vector3.zero;
        lastShadowPos = Vector3.zero;
    }
}
