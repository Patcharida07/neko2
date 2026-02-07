using UnityEngine;

public class ShadowLightPass5 : MonoBehaviour
{
    private Collider2D[] playerCols;

    void Awake()
    {
        playerCols = GetComponents<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("LightZone")) return;

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("ShadowGround");

        foreach (var box in boxes)
        {
            Collider2D[] boxCols = box.GetComponents<Collider2D>();

            foreach (var bCol in boxCols)
            {
                foreach (var pCol in playerCols)
                {
                    Physics2D.IgnoreCollision(pCol, bCol, true);
                }
            }
        }

        Debug.Log("💡 Light ON → Shadow can pass");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("LightZone")) return;

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("ShadowGround");

        foreach (var box in boxes)
        {
            Collider2D[] boxCols = box.GetComponents<Collider2D>();

            foreach (var bCol in boxCols)
            {
                foreach (var pCol in playerCols)
                {
                    Physics2D.IgnoreCollision(pCol, bCol, false);
                }
            }
        }

        Debug.Log("🌑 Light OFF → Shadow blocked");
    }
}
