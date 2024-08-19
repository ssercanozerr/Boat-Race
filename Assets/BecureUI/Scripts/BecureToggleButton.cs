using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BecureToggleButton : MonoBehaviour
{
    [SerializeField]
    bool PlaySoundFXonValueChange;
    Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void ToggleUpdated()
    {

        if (PlaySoundFXonValueChange)
        {
            UIManager.Instance.ToggleButton(toggle.isOn);
        }
    }
}
