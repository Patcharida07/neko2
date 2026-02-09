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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 给 Slider 调用的方法
    public void SetVolume(float value)
    {
        audioSource.volume = value;
    }

    // 如果你想让 Slider 读取当前音量
    public float GetVolume()
    {
        return audioSource.volume;
    }
}
