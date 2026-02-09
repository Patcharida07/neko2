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

            // 🔥 强制确保 Listener 是开的
            AudioListener.pause = false;
            AudioListener.volume = 1f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Slider 只调全局音量
    public void SetVolume(float value)
    {
        AudioListener.volume = Mathf.Max(value, 0.0001f);
    }

    public float GetVolume()
    {
        return AudioListener.volume;
    }
}
