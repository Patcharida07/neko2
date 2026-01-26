using UnityEngine;

public class SwitchController5 : MonoBehaviour
{
    public MovePlatform5 woodPlatform;
    public GameObject shadowLight;

    private GameObject currentPlayer;
    public GameObject shadowBox;
    public string solidLayer = "ShadowBox";
    public string passLayer = "LightZone";

    void Start()
    {
        shadowLight.SetActive(false); // ปิดไฟตอนเริ่ม
    }

    void Update()
    {
        if (currentPlayer != null && Input.GetKeyDown(KeyCode.E))
        {
            if (currentPlayer.CompareTag("Shadow"))
            {
                // ผู้เล่นเงากด
                woodPlatform.ToggleMove();
            }
            else if (currentPlayer.CompareTag("Player"))
            {
                // ผู้เล่นปกติกด
                ToggleLight();
            }
        }
    }

    void ToggleLight()
    {
        shadowLight.SetActive(!shadowLight.activeSelf);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Shadow"))
        {
            currentPlayer = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == currentPlayer)
        {
            currentPlayer = null;
        }
    }
}
