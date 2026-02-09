using UnityEngine;

public class BGM_Script : MonoBehaviour
{
    public static BGM_Script instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = Mathf.Clamp(value, 0f, 1f);
    }

    public float GetVolume()
    {
        return AudioListener.volume;
    }
}