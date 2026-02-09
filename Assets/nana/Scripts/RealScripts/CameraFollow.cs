using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public float fixedZ = -10f;

    [Header("Base Offset")]
    public Vector3 baseOffset;   // 👈 เพิ่มตัวนี้

    [Header("Limit X Movement")]
    public bool limitX = true;
    public float minX = 0f;
    public float maxX = 30f;

    private Vector3 extraOffset = Vector3.zero;
    private Vector3 zoneOffset = Vector3.zero;
    private bool shadowInZone = false;

    void LateUpdate()
    {
        if (target == null) return;

        float targetX = target.position.x;
        if (limitX) targetX = Mathf.Clamp(targetX, minX, maxX);

        Vector3 desiredPosition = new Vector3(
            targetX,
            target.position.y,
            fixedZ
        ) + baseOffset + extraOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;

        if (target != null && target.CompareTag("Player"))
            extraOffset = Vector3.zero;
        else if (target != null && target.CompareTag("Shadow"))
            extraOffset = shadowInZone ? zoneOffset : Vector3.zero;
    }

    public void SetZoneOffset(Vector3 offset, bool insideZone)
    {
        shadowInZone = insideZone;
        zoneOffset = offset;

        if (target != null && target.CompareTag("Shadow"))
            extraOffset = insideZone ? zoneOffset : Vector3.zero;
    }
}