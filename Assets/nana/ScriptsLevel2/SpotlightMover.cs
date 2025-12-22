using UnityEngine;
using System.Collections;

public class SpotlightMover : MonoBehaviour
{
    public float moveAmplitude = 4f;   // 左右最大距离
    public float moveSpeed = 2f;       // 移动速度
    public float waitTime = 3f;        // 端点停顿时间（秒）

    private Vector3 startPos;
    private int direction = 1;         // 1 = 向右，-1 = 向左
    private bool isWaiting = false;

    void Start()
    {
        startPos = transform.position;
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            if (!isWaiting)
            {
                // 移动
                transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

                float distanceFromStart = transform.position.x - startPos.x;

                // 到达右端
                if (distanceFromStart >= moveAmplitude)
                {
                    transform.position = new Vector3(
                        startPos.x + moveAmplitude,
                        startPos.y,
                        startPos.z
                    );

                    direction = -1;
                    yield return StartCoroutine(WaitAtEdge());
                }
                // 到达左端
                else if (distanceFromStart <= -moveAmplitude)
                {
                    transform.position = new Vector3(
                        startPos.x - moveAmplitude,
                        startPos.y,
                        startPos.z
                    );

                    direction = 1;
                    yield return StartCoroutine(WaitAtEdge());
                }
            }

            yield return null;
        }
    }

    IEnumerator WaitAtEdge()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
    }
}
