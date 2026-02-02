using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SwitchForShadow5 : MonoBehaviour
{
    public Light2D rightLight;
    public DoorLightController5 controller;
    private bool canPress;

    void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.E))
        {
            controller.ActivateRight();
        }

        if (!canPress) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");
            controller.ActivateRight();
        }
        //Tan
        if (Input.GetKeyDown(KeyCode.E))
        {
            rightLight.enabled = true;
        }

    }

     
    public void ActivateRight()
    {
        Debug.Log("ActivateRight CALLED");

        rightLight.enabled = true;
    }

    //public void ActivateRight()
    //{
    //    Debug.Log("ActivateRight called");
    //}

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
