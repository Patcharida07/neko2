using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalDoor5 : MonoBehaviour
{
    public GameObject lightA;
    public GameObject lightB;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!lightA.activeSelf || !lightB.activeSelf)
            return;

        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
        {
            Debug.Log("GAME CLEAR");
            SceneManager.LoadScene("5Congratulation");
        }
    }
}
