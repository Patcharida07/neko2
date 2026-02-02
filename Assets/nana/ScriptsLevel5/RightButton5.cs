using UnityEngine;

public class RightButton5 : MonoBehaviour
{
    public GameObject rightDoorPart;
    public GameObject lightB;

    private bool canPress;

    void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.E))
        {
            rightDoorPart.SetActive(true);
            lightB.SetActive(true);

            Debug.Log("RIGHT DOOR + LIGHT B ON");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
            canPress = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
            canPress = false;
    }
}
