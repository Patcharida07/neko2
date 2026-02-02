using UnityEngine;

public class Level3Initializer : MonoBehaviour
{
    public Transform playerSpawn;
    public Transform shadowSpawn;

    void Start()
    {
        if (GameManager.Instance == null) return;

        // รีเซต state ที่ไม่ควรค้าง
        GameManager.Instance.hasSavedPos = false;
        GameManager.Instance.lastRealPos = Vector3.zero;
        GameManager.Instance.lastShadowPos = Vector3.zero;

        // ย้าย Player / Shadow ไปจุดเริ่ม
        GameObject player = GameObject.FindWithTag("Player");
        GameObject shadow = GameObject.FindWithTag("Shadow");

        if (player != null)
            player.transform.position = playerSpawn.position;

        if (shadow != null)
            shadow.transform.position = shadowSpawn.position;
    }
}