using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum VolumeType
{
    SoundFX,
    MusicValue
}

public class BecureVolumeSlider : MonoBehaviour
{
    [SerializeField]
    VolumeType Type;


    [SerializeField]
    TMP_Text ValueText;

    [SerializeField]
    Slider Slider;

    [SerializeField]
    float SliderMultiplier = 1;

    [SerializeField]
    bool PlaySoundFXonValueChange;

    public void Start()
    {
        if (Type == VolumeType.MusicValue)
        {
            Slider.value = UIManager.Instance.MusicVolume;
        }
        else
        {
            Slider.value = UIManager.Instance.SoundFXVolume;
        }
        
        UpdateSliderValue();
    }

    public void UpdateSliderValue()
    {

        ValueText.text = (Slider.value * SliderMultiplier).ToString();

        if (Type == VolumeType.MusicValue)
        {
            UIManager.Instance.MusicVolume = (int)Slider.value;
        }
        else
        {
            UIManager.Instance.SoundFXVolume = (int)Slider.value;
        }
        

        if (PlaySoundFXonValueChange)
        {
            UIManager.Instance.SliderChange();
        }
    }

}
