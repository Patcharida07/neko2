using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorLightController5 : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;

    public GameObject realDoor; // ประตูจริง
    public Light2D lightLeft;
    public Light2D lightRight;

    public Collider2D doorCollider; // Collider ของประตูจริง

    private bool leftOpened = false;
    private bool rightOpened = false;

    void Start()
    {
        doorLeft.SetActive(false);
        doorRight.SetActive(false);
        realDoor.SetActive(false); // ประตูจริงเริ่มซ่อน
        lightLeft.enabled = false;
        lightRight.enabled = false;
        doorCollider.enabled = false;
    }

    public void ActivateLeft()
    {
        lightLeft.enabled = true;
        doorLeft.SetActive(true);
        leftOpened = true;
        CheckDoor();
    }

    public void ActivateRight()
    {
        lightRight.enabled = true;
        doorRight.SetActive(true);
        rightOpened = true;
        CheckDoor();
    }

    void CheckDoor()
    {
        if (leftOpened && rightOpened)
        {
            Debug.Log("Door UNLOCKED");
            realDoor.SetActive(true);
            doorCollider.enabled = true;
        }
    }

    public bool IsDoorUnlocked()
    {
        return leftOpened && rightOpened;
    }
}