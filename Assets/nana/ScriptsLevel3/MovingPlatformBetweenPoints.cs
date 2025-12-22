using UnityEngine;
using System.Collections;

public class MovingPlatformBetweenPoints : MonoBehaviour
{
    public Transform pointA;        // 起点
    public Transform pointB;        // 终点
    public float speed = 2f;        // 移动速度
    public float waitTime = 3f;     // 端点停留时间（秒）

    private Vector3 targetPos;      // 当前目标点
    private bool isWaiting = false; // 是否在等待

    void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("请在 Inspector 中绑定 pointA 和 pointB");
            enabled = false;
            return;
        }

        transform.position = pointA.position;
        targetPos = pointB.position;
    }

    void Update()
    {
        if (isWaiting) return;

        // 向目标点移动
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );

        // 到达端点
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            StartCoroutine(WaitAndSwitch());
        }
    }

    IEnumerator WaitAndSwitch()
    {
        isWaiting = true;

        yield return new WaitForSeconds(waitTime);

        // 切换目标点
        targetPos = (targetPos == pointA.position)
            ? pointB.position
            : pointA.position;

        isWaiting = false;
    }

    // 让角色跟随平台移动
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") ||
            collision.collider.CompareTag("Shadow"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") ||
            collision.collider.CompareTag("Shadow"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
