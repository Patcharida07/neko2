using UnityEngine;

public class SwitchForShadow5 : MonoBehaviour
{
    public DoorLightController5 controller;
    private bool canPress;

    void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.E))
        {
            controller.ActivateRight();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
            canPress = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
            canPress = false;
    }
}