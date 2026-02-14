using UnityEngine;

public class DebugShadowHit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("💥 Shadow COLLISION with → " + col.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("🔥 Shadow TRIGGER with → " + other.gameObject.name);
    }
}