using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{

    [HideInInspector]
    public static UIManager Instance;


    [SerializeField]
    AudioClip ButtonHoverClip;
    [SerializeField]
    AudioClip ButtonClickClip;
    [SerializeField]
    AudioClip WarningClip;
    [SerializeField]
    AudioClip SliderClip;
    [SerializeField]
    AudioClip ToggleOnClip;
    [SerializeField]
    AudioClip ToggleOffClip;

    [SerializeField]
    AudioClip CoinClip;

    [SerializeField]
    float LeanTime;
    GameObject ActivePanel;

    bool isanimating;


    [SerializeField]
    AudioMixer audioMixer;
    int _SoundFXVolume=100;
    int _MusicVolume = 100;

    public int SoundFXVolume
    {
        get { return _SoundFXVolume; }
        set { _SoundFXVolume = value;
            PlayerPrefs.SetInt("SoundFXVolume", value);
        }
    }

    public int MusicVolume
    {
        get { return _MusicVolume; }
        set
        {
            _MusicVolume = value;
            PlayerPrefs.SetInt("MusicVolume", value);
            UpdateMixerVolume();
        }
    }
    // Start is called before the first frame update


    private void Awake()
    {
        if (!UIManager.Instance)
        {
            UIManager.Instance = this;
        }

        if (UIManager.Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        SoundFXVolume = PlayerPrefs.GetInt("SoundFXVolume", 100);
        MusicVolume = PlayerPrefs.GetInt("MusicVolume", 100);

    }

    void UpdateMixerVolume()
    {
        audioMixer.SetFloat("MusicVol",Mathf.Log10(((float)MusicVolume+0.1f) / 100) *20);
    }


    public void PlaySoundFX(AudioClip Clip)
    {
        AudioSource.PlayClipAtPoint(Clip, Camera.main.transform.position, ((float)SoundFXVolume)/100);
    }


    public void ButtonHover()
    {
        PlaySoundFX(ButtonHoverClip);
    }
    public void ButtonClick()
    {
        PlaySoundFX(ButtonClickClip);
    }
    public void SliderChange()
    {
        PlaySoundFX(SliderClip);
    }

    public void AddCoinFX()
    {
        PlaySoundFX(CoinClip);  
    }

    public void ToggleButton(bool Active)
    {
        if (Active)
        {
            PlaySoundFX(ToggleOnClip);
            return;
        }
        PlaySoundFX(ToggleOffClip);
    }

    public void OpenPanel(GameObject Panel)
    {
        if (isanimating) { return; }

        if(ActivePanel == Panel)
        {
            return;
        }
        if (ActivePanel)
        {
            ClosePanel(ActivePanel);
        }

        isanimating = true;

        ActivePanel = Panel;
        Panel.SetActive(true);
        Panel.transform.localScale = Vector3.zero;
        LeanTween.scale(Panel, Vector3.one, LeanTime).setEase(LeanTweenType.easeInQuart);

        isanimating = false;
    }
    public void ClosePanel(GameObject Panel)
    {
        if (isanimating) { return; }

        isanimating = true;

        LeanTween.scale(Panel, Vector3.zero, LeanTime).setEase(LeanTweenType.easeOutQuart).setOnComplete(
            () => { Panel.SetActive(false); });
        ActivePanel = null;

        isanimating = false;
    }

    public void OpenPanelL2R(GameObject Panel)
    {

        if (isanimating) { return; }



        if (ActivePanel == Panel)
        {
            return;
        }
        if (ActivePanel)
        {
            ClosePanel(ActivePanel);
        }

        isanimating = true;

        ActivePanel = Panel;
        Panel.SetActive(true);
        Panel.transform.localScale = Vector3.one;
        Panel.transform.position=new Vector3(Screen.width*2,Screen.height/2,0);

        LeanTween.moveLocalX(Panel, 0, LeanTime*2).setEase(LeanTweenType.easeInQuart);

        isanimating = false;


    }
    public void ClosePanelL2R(GameObject Panel)
    {
        if (isanimating) { return; }

        isanimating = true;
        Panel.transform.localScale = Vector3.one;
        LeanTween.moveLocalX(Panel, Screen.width * 2, LeanTime*2).setEase(LeanTweenType.easeInQuart).setOnComplete(
            () => { Panel.SetActive(false); });
        ActivePanel = null;

        isanimating = false;


    }
}
