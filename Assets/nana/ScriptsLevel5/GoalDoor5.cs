using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalDoor5 : MonoBehaviour
{
    public DoorLightController5 controller;

    private bool playerInside = false;
    private bool shadowInside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!controller.IsDoorUnlocked()) return;

        if (other.CompareTag("Player"))
            playerInside = true;

        if (other.CompareTag("Shadow"))
            shadowInside = true;

        if (playerInside && shadowInside)
        {
            Debug.Log("GAME CLEAR");
            SceneManager.LoadScene("5Congratulation");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;

        if (other.CompareTag("Shadow"))
            shadowInside = false;
    }
}