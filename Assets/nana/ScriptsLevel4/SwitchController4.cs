using UnityEngine;

public class SwitchController4 : MonoBehaviour
{
    
    public LightCircleController lightSwitcher;
    private bool canPress;

    void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.E))
        {
            lightSwitcher.Toggle();
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
