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
}
