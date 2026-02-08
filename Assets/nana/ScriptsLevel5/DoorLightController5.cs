using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorLightController5 : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;

    public Light2D lightLeft;
    public Light2D lightRight;

    public Collider2D doorCollider;
    public GameObject finalDoor;

    private bool leftOpened = false;
    private bool rightOpened = false;

    void Awake()
    {
        doorLeft.SetActive(false);
        doorRight.SetActive(false);

        lightLeft.enabled = false;
        lightRight.enabled = false;

        doorCollider.enabled = false;
        finalDoor.SetActive(false);

        Debug.Log("Force lights OFF");
    }

    public bool IsDoorUnlocked()
    {
        return leftOpened && rightOpened;
    }
    public void ActivateLeft()
    {
        if (leftOpened) return;

        Debug.Log("LEFT ONLY");

        leftOpened = true;
        lightLeft.enabled = true;
        doorLeft.SetActive(true);

        CheckDoor();
    }

    public void ActivateRight()
    {
        if (rightOpened) return;

        Debug.Log("RIGHT ONLY");

        rightOpened = true;
        lightRight.enabled = true;
        doorRight.SetActive(true);

        CheckDoor();
    }


    void CheckDoor()
    {
        if (leftOpened && rightOpened)
        {
            doorCollider.enabled = true;

            if (finalDoor != null)
                finalDoor.SetActive(true);

            Debug.Log("🚪 Door UNLOCKED");
        }
    }



}