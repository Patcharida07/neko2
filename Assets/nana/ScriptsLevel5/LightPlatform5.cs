using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPlatform5 : MonoBehaviour
{
    public Light2D light2D;
    public Collider2D platformCollider;
    public bool startActive = false;
    void Awake()
    {
        if (light2D == null)
            light2D = GetComponent<Light2D>();

        if (platformCollider == null)
            platformCollider = GetComponent<Collider2D>();

        SetActive(startActive);//ถ้าอยากเลือกได้ว่า “เริ่มติดหรือเริ่มดับ”ติ๊ก startActive
    }

    public void TurnOn()
    {
        light2D.enabled = true;
        platformCollider.enabled = true;
    }

    public void TurnOff()
    {
        platformCollider.enabled = false;
        light2D.enabled = false;
    }

    public void SetActive(bool active)
    {
        platformCollider.enabled = active;
        light2D.enabled = active;
    }
}