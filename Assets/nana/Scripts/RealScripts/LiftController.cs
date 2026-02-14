using UnityEngine;
using System.Collections;

public class LiftController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float waitTime = 3f;

    private int currentWaypoint = 0;
    private bool isActive = false;
    private bool isWaiting = false;

    void FixedUpdate()
    {
        if (!isActive || isWaiting) return;

        Vector2 targetPos = waypoints[currentWaypoint].position;

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.fixedDeltaTime
        );

        if (Vector2.Distance(transform.position, targetPos) < 0.05f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        isWaiting = false;
    }

    public void Toggle()
    {
        isActive = !isActive;
        Debug.Log(isActive ? "ลิฟต์เปิดทำงาน" : "ลิฟต์ปิดแล้ว");
    }

    // =============================
    // ขึ้นลิฟต์
    // =============================
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Shadow"))
        {
            collision.transform.SetParent(transform);
        }
    }

    // =============================
    // ลงลิฟต์
    // =============================
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Shadow"))
        {
            StartCoroutine(DetachNextFrame(collision.transform));
        }
    }

    IEnumerator DetachNextFrame(Transform t)
    {
        yield return null; // ⭐ รอ 1 เฟรม

        if (t != null && t.gameObject.activeInHierarchy)
        {
            t.SetParent(null);
        }
    }
}