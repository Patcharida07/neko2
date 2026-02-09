using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SwitchForPlayer5 : MonoBehaviour
{
    public Light2D rightLight;
    public DoorLightController5 controller;
    private bool canPress;

    void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.E))
        {
            controller.ActivateLeft();
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            canPress = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            canPress = false;
    }
}
