using UnityEngine;
using System.Collections;

public class MovingPlatformInZone : MonoBehaviour
{
    public Transform pointA;      // 起点
    public Transform pointB;      // 终点
    public float speed = 4f;      // 移动速度
    public float waitTime = 3f;   // 端点停留时间（秒）

    private Vector3 targetPos;
    private bool isWaiting = false;

    private void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Please assign pointA and pointB in the inspector.");
            enabled = false;
            return;
        }

        transform.position = pointA.position;
        targetPos = pointB.position;
    }

    private void Update()
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
            StartCoroutine(WaitAtPoint());
        }
    }

    IEnumerator WaitAtPoint()
    {
        isWaiting = true;

        // 停留
        yield return new WaitForSeconds(waitTime);

        // 切换目标点
        targetPos = (targetPos == pointA.position) ? pointB.position : pointA.position;

        isWaiting = false;
    }
}
