using UnityEngine;
using System.Collections;

public class WorldSwitcher : MonoBehaviour
{
    public GameObject realPlayer;
    public GameObject shadowPlayer;
    public CameraFollow cameraFollow;

    private bool isControllingReal = true;

    public Transform GetActivePlayer()
    {
        return isControllingReal ? realPlayer.transform : shadowPlayer.transform;
    }

    IEnumerator Start()
    {
        if (cameraFollow == null)
            cameraFollow = Camera.main.GetComponent<CameraFollow>();

        realPlayer.SetActive(true);
        shadowPlayer.SetActive(true);

        Rigidbody2D rb1 = realPlayer.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = shadowPlayer.GetComponent<Rigidbody2D>();

        rb1.simulated = false;
        rb2.simulated = false;

        yield return null;

        // Spawn จากตำแหน่งเดิมถ้ามากลับจาก puzzle
        if (GameManager.Instance != null
            && GameManager.Instance.hasSavedPos
            && GameManager.Instance.comingFromPuzzle)
        {
            realPlayer.transform.position = GameManager.Instance.lastRealPos;
            shadowPlayer.transform.position = GameManager.Instance.lastShadowPos;
            GameManager.Instance.comingFromPuzzle = false;
        }
        else
        {
            GameObject spawn = GameObject.Find("SpawnPoint");
            if (spawn != null)
            {
                realPlayer.transform.position = spawn.transform.position;
                shadowPlayer.transform.position = spawn.transform.position + Vector3.right * 1.5f;
            }
        }

        rb1.linearVelocity = Vector2.zero;
        rb2.linearVelocity = Vector2.zero;

        rb1.simulated = true;
        rb2.simulated = true;

        SetPlayerControl(realPlayer, true);
        SetPlayerControl(shadowPlayer, false);

        cameraFollow?.SetTarget(realPlayer.transform);

        Collider2D realCol = realPlayer.GetComponent<Collider2D>();
        Collider2D shadowCol = shadowPlayer.GetComponent<Collider2D>();
        if (realCol != null && shadowCol != null)
            Physics2D.IgnoreCollision(realCol, shadowCol, true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isControllingReal = !isControllingReal;

            GameObject active = isControllingReal ? realPlayer : shadowPlayer;
            GameObject inactive = isControllingReal ? shadowPlayer : realPlayer;

            SetPlayerControl(active, true);
            SetPlayerControl(inactive, false);

            cameraFollow?.SetTarget(active.transform);
        }

        if (Input.GetKeyDown(KeyCode.R))
            ResetPlayers();
    }

    void SetPlayerControl(GameObject obj, bool active)
    {
        var pc = obj.GetComponent<PlayerController>();
        if (pc != null) pc.enabled = active;

        var rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.isKinematic = false;
        }
    }

    void ResetPlayers()
    {
        GameObject spawn = GameObject.Find("SpawnPoint");
        if (spawn != null)
        {
            realPlayer.transform.position = spawn.transform.position;
            shadowPlayer.transform.position = spawn.transform.position + Vector3.right * 1.5f;
        }

        Rigidbody2D rb1 = realPlayer.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = shadowPlayer.GetComponent<Rigidbody2D>();
        if (rb1 != null) rb1.linearVelocity = Vector2.zero;
        if (rb2 != null) rb2.linearVelocity = Vector2.zero;

        isControllingReal = true;

        SetPlayerControl(realPlayer, true);
        SetPlayerControl(shadowPlayer, false);

        cameraFollow?.SetTarget(realPlayer.transform);
    }
}