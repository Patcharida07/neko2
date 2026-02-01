using UnityEngine;

public class LightCircleController5 : MonoBehaviour
{
    public LightPlatform5 lightA;
    public LightPlatform5 lightB;

    private bool isAActive = false; // เริ่มต้นยังไม่เลือกฝั่งไหน

    void Start()
    {
        // 🔌 ดับหมดตั้งแต่เริ่ม
        lightA.SetActive(false);
        lightB.SetActive(false);
    }

    public void Toggle()
    {
        isAActive = !isAActive;
        UpdateLights();
    }

    void UpdateLights()
    {
        lightA.SetActive(isAActive);
        lightB.SetActive(!isAActive);
    }
    
}
