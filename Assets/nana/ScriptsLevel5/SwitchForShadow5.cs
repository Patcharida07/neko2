using UnityEngine;

public class SwitchForShadow5 : MonoBehaviour
{
    public GameObject doorLight;

    private bool playerInside = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
            playerInside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
            playerInside = false;
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            doorLight.SetActive(true);
        }
    }
}