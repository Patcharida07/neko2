using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        if (slider == null) return;

        // Sync Slider กับ volume ปัจจุบัน
        if (BGM_Script.instance != null)
            slider.value = BGM_Script.instance.GetVolume();

        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    void OnSliderChanged(float value)
    {
        if (BGM_Script.instance != null)
            BGM_Script.instance.SetVolume(value);
    }
}