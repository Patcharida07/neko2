using UnityEngine;

public class LeftButton5 : MonoBehaviour
{
    public GameObject leftDoorPart;
    public GameObject lightA;   // ← 灯

    private bool canPress;

    void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.E))
        {
            leftDoorPart.SetActive(true);
            lightA.SetActive(true);   // ← 关键就这一行

            Debug.Log("LEFT DOOR + LIGHT A ON");
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
