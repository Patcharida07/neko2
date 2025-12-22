using UnityEngine;
using System.Collections;

public class LiftController : MonoBehaviour
{
    public Transform[] waypoints;   // 上下移动的点
    public float speed = 5f;
    public float waitTime = 3f;     // ⭐ 端点停留时间（秒）

    private int currentWaypoint = 0;
    private bool isActive = false;  // 电梯是否启用
    private bool isWaiting = false; // ⭐ 是否正在停留

    void FixedUpdate()
    {
        if (!isActive || isWaiting) return;

        Vector2 targetPos = waypoints[currentWaypoint].position;

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.fixedDeltaTime
        );

        // 到达 waypoint
        if (Vector2.Distance(transform.position, targetPos) < 0.05f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;

        // ⭐ 在端点停留
        yield return new WaitForSeconds(waitTime);

        // 切换到下一个 waypoint
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;

        isWaiting = false;
    }

    // 开关电梯
    public void Toggle()
    {
        isActive = !isActive;
        Debug.Log(isActive ? "ลิฟต์เปิดทำงาน" : "ลิฟต์ปิดแล้ว");
    }

    // 玩家站在电梯上 → 跟随移动
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    // 玩家离开电梯
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
