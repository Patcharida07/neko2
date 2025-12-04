using UnityEngine;

public class PlayerRespaw : MonoBehaviour
{
    [SerializeField] private bool isRealPlayer = true;
    // ตั้งใน Inspector: 
    // ✔ Real Player = true
    // ✔ Shadow Player = false

    void Start()
    {
        if (!isRealPlayer) return;  // ❗ ป้องกัน Shadow ถูกย้ายตำแหน่ง

        if (GameManager.Instance != null && GameManager.Instance.hasSavedPos)
        {
            // ย้ายเฉพาะตัวจริงกลับไปจุดล่าสุด
            transform.position = GameManager.Instance.lastRealPos;
        }
    }
}