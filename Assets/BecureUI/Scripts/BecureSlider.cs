using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BecureSlider : MonoBehaviour
{


    [SerializeField]
    TMP_Text ValueText;

    [SerializeField]
    Slider Slider;

    [SerializeField]
    float SliderMultiplier=1;

    [SerializeField]
    bool PlaySoundFXonValueChange;

    public void Start()
    {
        UpdateSliderValue();
    }

    public void UpdateSliderValue()
    {

        ValueText.text = (Slider.value * SliderMultiplier).ToString();

        if (PlaySoundFXonValueChange)
        {
            UIManager.Instance.SliderChange();
        }
    }

}
