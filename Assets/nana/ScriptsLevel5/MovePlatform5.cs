using UnityEngine;

public class MovePlatform5 : MonoBehaviour
{
    public Transform upPos;
    public Transform downPos;
    public float speed = 2f;

    private bool isUp;

    void Start()
    {
        // เช็คตำแหน่งเริ่มต้น
        float distToUp = Vector2.Distance(transform.position, upPos.position);
        float distToDown = Vector2.Distance(transform.position, downPos.position);

        isUp = distToUp < distToDown;
    }

    void Update()
    {
        Transform target = isUp ? upPos : downPos;
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );
    }

    public void ToggleMove()
    {
        isUp = !isUp;
    }
}