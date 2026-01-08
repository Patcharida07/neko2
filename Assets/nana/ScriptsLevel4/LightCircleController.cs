using UnityEngine;

public class LightCircleController : MonoBehaviour
{
    public LightPlatform4 lightA;
    public LightPlatform4 lightB;

    private bool isAActive = true;

    void Start()
    {
        UpdateLights();
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
