using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPlatform4 : MonoBehaviour
{
    public Light2D light2D;
    public Collider2D platformCollider;

    void Awake()
    {
        // ถ้ายังไม่ได้ลาก จะ auto หาให้
        if (light2D == null)
            light2D = GetComponent<Light2D>();

        if (platformCollider == null)
            platformCollider = GetComponent<Collider2D>();
    }

    public void TurnOn()
    {
        light2D.enabled = true;
        platformCollider.enabled = true;
    }

    public void TurnOff()
    {
        // ปิด collider ก่อน = ตกทันที
        platformCollider.enabled = false;
        light2D.enabled = false;
    }

    public void SetActive(bool active)
    {
        platformCollider.enabled = active;
        light2D.enabled = active;
    }
}
