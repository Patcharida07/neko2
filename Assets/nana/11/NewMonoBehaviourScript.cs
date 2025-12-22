using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float moveAmplitude = 3f;   // 上下最大距离
    public float moveSpeed = 2f;       // 移动速度
    public float waitTime = 3f;        // 端点停顿时间（秒）

    private Vector3 startPos;
    private int direction = 1;         // 1 = 向上，-1 = 向下
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
                // ⭐ 上下移动
                transform.position += Vector3.up * direction * moveSpeed * Time.deltaTime;

                float distanceFromStart = transform.position.y - startPos.y;

                // 到达上端
                if (distanceFromStart >= moveAmplitude)
                {
                    transform.position = new Vector3(
                        startPos.x,
                        startPos.y + moveAmplitude,
                        startPos.z
                    );

                    direction = -1;
                    yield return StartCoroutine(WaitAtEdge());
                }
                // 到达下端
                else if (distanceFromStart <= -moveAmplitude)
                {
                    transform.position = new Vector3(
                        startPos.x,
                        startPos.y - moveAmplitude,
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
