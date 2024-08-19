using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BecureSliderText : MonoBehaviour
{
    [SerializeField]
    string[] Texts;


    [SerializeField]
    TMP_Text ValueText;

    [SerializeField]
    Slider Slider;

    [SerializeField]
    bool PlaySoundFXonValueChange;


    private void Start()
    {
        UpdateSliderValue();
    }

    public void UpdateSliderValue()
    {
        //Add Localization Script Here
        ValueText.text = Texts[(int)Slider.value];


        if (PlaySoundFXonValueChange)
        {
            UIManager.Instance.SliderChange();
        }
    }

}
