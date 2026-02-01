using UnityEngine;

public class SwitchController6 : MonoBehaviour
{
    public LightCircleController5 lightSwitcher;
    private bool canPress = false;

    void Update()
    {
        if (!canPress) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (lightSwitcher != null)
            {
                lightSwitcher.Toggle();
            }
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
