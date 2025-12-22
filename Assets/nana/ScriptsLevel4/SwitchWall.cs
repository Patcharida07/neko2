using UnityEngine;

public class SwitchWall : MonoBehaviour
{
    public GameObject wall;        // wall to move
    public float moveSpeed = 3f;   // how fast wall goes up
    public float moveDistance = 3f; // how far wall moves up

    private bool playerInRange = false;
    private bool activated = false;
    private Vector3 wallStartPos;

    void Start()
    {
        wallStartPos = wall.transform.position;
    }

    void Update()
    {
        // Press E to activate switch
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !activated)
        {
            activated = true;
        }

        // Move wall up
        if (activated)
        {
            wall.transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            // When wall moves enough ¨ disappear
            if (wall.transform.position.y >= wallStartPos.y + moveDistance)
            {
                wall.SetActive(false);
                activated = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            playerInRange = false;
        }
    }
}

