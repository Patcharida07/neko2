using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalDoor5 : MonoBehaviour
{
    public DoorLightController5 controller;
    public string nextSceneName = "5Congratulation";

    private bool playerInside = false;
    private bool shadowInside = false;
    private bool triggered = false;
    private Animator animator;

    void Start()
    {
        animator = controller.realDoor.GetComponent<Animator>(); // Animator ของประตูจริง
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!controller.IsDoorUnlocked()) return;

        if (collision.CompareTag("Player"))
            playerInside = true;

        if (collision.CompareTag("Shadow"))
            shadowInside = true;

        if (playerInside && shadowInside && !triggered)
        {
            triggered = true;
            StartCoroutine(OpenDoorAndChangeScene());
        }
    }

    IEnumerator OpenDoorAndChangeScene()
    {
        animator.SetTrigger("Open");        // เปิดอนิเมชัน
        yield return new WaitForSeconds(1.5f); // รอให้ Animation เล่นจบ
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInside = false;
        if (collision.CompareTag("Shadow"))
            shadowInside = false;

        // ⭐ ตรวจสอบ triggered ด้วย
        if (playerInside && shadowInside && !triggered)
        {
            triggered = true; // ตั้งว่าถูกเรียกแล้ว
            StartCoroutine(OpenDoorAndChangeScene());

            Debug.Log("Trigger entered: Player=" + playerInside + ", Shadow=" + shadowInside + ", triggered=" + triggered);

        }
    }
}