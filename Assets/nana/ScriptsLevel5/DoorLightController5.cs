using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorLightController5 : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;

    public Light2D lightLeft;
    public Light2D lightRight;

    public Collider2D doorCollider; // 👈 ประตูจริง

    private bool leftOpened = false;
    private bool rightOpened = false;

    void Start()
    {
        // ❌ ซ่อนทุกอย่าง
        doorLeft.SetActive(false);
        doorRight.SetActive(false);

        lightLeft.enabled = false;
        lightRight.enabled = false;

        doorCollider.enabled = false; // 🚫 ยังผ่านไม่ได้
    }

    public void ActivateLeft()
    {
        Debug.Log("Activate LEFT");

        lightLeft.enabled = true;
        doorLeft.SetActive(true);
    }

    public void ActivateRight()
    {
        Debug.Log("Activate RIGHT");

        lightRight.enabled = true;
        doorRight.SetActive(true);
    }

    void CheckDoor()
    {
        // 🔓 เปิดครบสองฝั่ง
        if (leftOpened && rightOpened)
        {
            doorCollider.enabled = true;
            Debug.Log("Door UNLOCKED");
        }
    }
}