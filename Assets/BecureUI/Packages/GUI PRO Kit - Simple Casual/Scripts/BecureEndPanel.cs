using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BecureEndPanel : MonoBehaviour
{

    [SerializeField]
    AudioClip SuccessSoundFX;
    [SerializeField]
    AudioClip FailSoundFX;
    [SerializeField]
    AudioClip ResultsSoundFX;

    [SerializeField]
    GameObject ScreenDim;
    [SerializeField]
    GameObject Elements;
    [SerializeField]
    GameObject SuccessElements;
    [SerializeField]
    GameObject FailElements;
    [SerializeField]
    GameObject[] ResultElements;
    int ResultElementIndex=0;

    [SerializeField]
    GameObject PopUp;
    // Start is called before the first frame update
    void Start()
    {
    }


    //If Game ends with a success run with EndPanel(True) if not EndPanel(False)
    public void EndPanel(bool issucces)
    {
        Elements.SetActive(true);
        PopUp.transform.localScale = new Vector3(PopUp.transform.localScale.x, 0, PopUp.transform.localScale.y);
        foreach(GameObject a in ResultElements)
        {
            a.transform.localScale = Vector3.zero;
        }


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
                       GameObject ObjectToAnimate=null;
                       if (issucces)
                       {
                           SuccessElements.transform.localScale = Vector3.zero;
                           SuccessElements.SetActive(true);
                           ObjectToAnimate = SuccessElements;
                           UIManager.Instance.PlaySoundFX(SuccessSoundFX);


                       }
                       else
                       {
                           FailElements.transform.localScale = Vector3.zero;
                           FailElements.SetActive(true);
                           ObjectToAnimate = FailElements;
                           UIManager.Instance.PlaySoundFX(FailSoundFX);
                       }

                       LeanTween.scale(ObjectToAnimate, Vector3.one, 1f).setEase(LeanTweenType.easeOutQuart).setOnComplete(
                   () =>
                       {
                           ScaleButton();

                       });
                   });


            });

    }

    void ScaleButton()
    {
        if (ResultElementIndex >= ResultElements.Length) { return; }

        UIManager.Instance.PlaySoundFX(ResultsSoundFX);
        LeanTween.scale(ResultElements[ResultElementIndex], Vector3.one, .5f).setEase(LeanTweenType.easeInQuart).setOnComplete(
        () =>
        {
            ResultElementIndex++;
            
            ScaleButton();
        });
    }
}
