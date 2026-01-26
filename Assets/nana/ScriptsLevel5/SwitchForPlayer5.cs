using UnityEngine;

public class SwitchForPlayer5 : MonoBehaviour
{
    public GameObject doorLight;

    private bool playerInside = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
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