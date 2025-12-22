using UnityEngine;
using System.Collections;

public class SwingingPlatform : MonoBehaviour
{
    [Header("Platforms")]
    public Transform SpotlightRoot1;   // 平台1
    public Transform SpotlightRoot2;   // 平台2

    [Header("Movement")]
    public float speed = 2f;           // 移动速度
    public float meetWaitTime = 3f;    // 中间停留时间

    private Vector3 startPos1;
    private Vector3 startPos2;
    private Vector3 meetPos;

    private bool isWaiting = false;
    private bool goingToMeet = true;

    void Start()
    {
        if (SpotlightRoot1 == null || SpotlightRoot2 == null)
        {
            Debug.LogError("请在 Inspector 中绑定 SpotlightRoot1 和 SpotlightRoot2");
            enabled = false;
            return;
        }

        // 原来的 Start 代码……
        startPos1 = SpotlightRoot1.position;
        startPos2 = SpotlightRoot2.position;

        // 中间对接点 = 两个平台初始位置的中点
        meetPos = (startPos1 + startPos2) / 2f;

        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            if (!isWaiting)
            {
                Vector3 target1 = goingToMeet ? meetPos : startPos1;
                Vector3 target2 = goingToMeet ? meetPos : startPos2;

                SpotlightRoot1.position = Vector3.MoveTowards(
                    SpotlightRoot1.position,
                    target1,
                    speed * Time.deltaTime
                );

                SpotlightRoot2.position = Vector3.MoveTowards(
                    SpotlightRoot2.position,
                    target2,
                    speed * Time.deltaTime
                );

                // 两个平台都到达目标
                bool p1Arrived = Vector3.Distance(SpotlightRoot1.position, target1) < 0.01f;
                bool p2Arrived = Vector3.Distance(SpotlightRoot2.position, target2) < 0.01f;

                if (p1Arrived && p2Arrived)
                {
                    isWaiting = true;
                    yield return new WaitForSeconds(meetWaitTime);

                    goingToMeet = !goingToMeet;
                    isWaiting = false;
                }
            }

            yield return null;
        }
    }
}
