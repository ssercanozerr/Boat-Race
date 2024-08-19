using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BecureSettingsPanel : MonoBehaviour
{
    [SerializeField]
    GameObject Elements;

    [SerializeField]
    GameObject ScreenDim;

    [SerializeField]
    GameObject PopUp;
    [SerializeField]
    GameObject Button;
    [SerializeField]
    GameObject Text;


    private void Start()
    {
        //OpenSettingsPanel();
    }

    public void OpenSettingsPanel()
    {
        Elements.SetActive(true);
        PopUp.transform.localScale = new Vector3(PopUp.transform.localScale.x, 0, PopUp.transform.localScale.y);
        Button.transform.localScale = Vector3.zero;
        Text.transform.localScale = Vector3.zero;

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
           LeanTween.scale(Button, Vector3.one, .2f).setEase(LeanTweenType.easeOutQuart);
           LeanTween.scale(Text, Vector3.one, .2f).setEase(LeanTweenType.easeOutQuart);
       });
            });
    }
    public void CloseSettingsPanel()
    {
        LeanTween.scale(Button, Vector3.zero, .2f).setEase(LeanTweenType.easeOutQuart);
        LeanTween.scale(Text, Vector3.zero, .2f).setEase(LeanTweenType.easeOutQuart).setOnComplete(
        () =>
        {

            LeanTween.scale(PopUp, new Vector3(PopUp.transform.localScale.x, 0, PopUp.transform.localScale.y), .2f).setEase(LeanTweenType.easeOutQuart).setOnComplete(
         () =>
         {
             Image r = ScreenDim.GetComponent<Image>();
             LeanTween.value(ScreenDim, .85f, 0f, .25f).setOnUpdate((float val) =>
             {
                 Color c = r.color;
                 c.a = val;
                 r.color = c;
             }).setOnComplete(
                 () =>
                 {
                     Elements.SetActive(false);
                 });
         });
        });

    }
}
