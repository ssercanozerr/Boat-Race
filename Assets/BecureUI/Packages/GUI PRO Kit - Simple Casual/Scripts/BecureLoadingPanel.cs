using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BecureLoadingPanel : MonoBehaviour
{
    [SerializeField]
    GameObject ScreenDim;
    [SerializeField]
    GameObject Logo;
    [SerializeField]
    GameObject Rotate;

    [SerializeField]
    AnimationCurve Curve;
    // Start is called before the first frame update
    void Start()
    {
        LoadingPanelDeactive();
    }


    void LoadingPanelActive()
    {
        Image r = ScreenDim.GetComponent<Image>();
        Image r2 = Logo.GetComponent<Image>();

        LeanTween.rotateY(Rotate, 90, 2).setEase(Curve).setLoopPingPong();

        LeanTween.value(ScreenDim, 0, 1, .25f).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;


        });
        LeanTween.value(Logo, 0, 1, .25f).setOnUpdate((float val) =>
        {
            Color c = r2.color;
            c.a = val;
            r2.color = c;


        });
    }
    void LoadingPanelDeactive()
    {
        Image r = ScreenDim.GetComponent<Image>();
        Image r2 = Logo.GetComponent<Image>();

        LeanTween.rotateY(Rotate, 0, 2).setEase(Curve);

        LeanTween.value(ScreenDim, 1, 0, 1f).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;


        });
        LeanTween.value(Logo, 1, 0, 1f).setOnUpdate((float val) =>
        {
            Color c = r2.color;
            c.a = val;
            r2.color = c;


        }).setOnComplete(()
        =>
        {
            gameObject.SetActive(false);
        });
    }
}
