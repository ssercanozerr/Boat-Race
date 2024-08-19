using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BecureAuthorizationPanel : MonoBehaviour
{
    [SerializeField]
    GameObject Elements;
    [SerializeField]
    GameObject AuthPanel;
    [SerializeField]
    GameObject ScreenDim;
    [SerializeField]
    GameObject Icon;
    [SerializeField]
    GameObject PopUp;
    [SerializeField]
    GameObject Button;
    [SerializeField]
    AudioClip WarningClip;

    // Start is called before the first frame update
    void Start()
    {
        OpenUnAuthPanel();
    }

    // Update is called once per frame

    public void OpenUnAuthPanel()
    {
        Elements.SetActive(true);
        PopUp.transform.localScale = new Vector3(PopUp.transform.localScale.x,0, PopUp.transform.localScale.y);
        Icon.transform.localScale = Vector3.zero;
        Button.transform.localScale = Vector3.zero;

        Image r = ScreenDim.GetComponent<Image>();
        LeanTween.value(ScreenDim, 0, .85f, .25f).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(
            () =>
            {
                LeanTween.scale(PopUp, Vector3.one, .2f).setEase(LeanTweenType.easeInQuart).setOnComplete(
       () =>
       {
           AudioSource.PlayClipAtPoint(WarningClip, Camera.main.transform.position);
           LeanTween.scale(Icon, Vector3.one, .2f).setEase(LeanTweenType.easeOutQuart);
           LeanTween.scale(Button, Vector3.one, .2f).setEase(LeanTweenType.easeOutQuart);
       });
            });
    }

    public void CloseUnAuthPanel()
    {
        AuthPanel.SetActive(false);
    }


}
