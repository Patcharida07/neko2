using UnityEngine;

public class ShadowLightPass5 : MonoBehaviour
{
   private Collider2D playerCol;

    void Awake()
    {
        playerCol = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("LightZone")) return;

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("ShadowBox");
        foreach (var box in boxes)
        {
            Collider2D boxCol = box.GetComponent<Collider2D>();
            if (boxCol != null)
                Physics2D.IgnoreCollision(playerCol, boxCol, true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("LightZone")) return;

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("ShadowBox");
        foreach (var box in boxes)
        {
            Collider2D boxCol = box.GetComponent<Collider2D>();
            if (boxCol != null)
                Physics2D.IgnoreCollision(playerCol, boxCol, false);
        }
    }
}