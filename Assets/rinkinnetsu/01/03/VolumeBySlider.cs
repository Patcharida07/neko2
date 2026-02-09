using UnityEngine;
using UnityEngine.UI;

public class VolumeBySlider : MonoBehaviour
{
    public AudioSource bgmSource;
    public Slider volumeSlider;

    void Start()
    {
        // 初始音量
        volumeSlider.value = bgmSource.volume;

        // 监听 Slider 改变
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        bgmSource.volume = value;
    }
}
