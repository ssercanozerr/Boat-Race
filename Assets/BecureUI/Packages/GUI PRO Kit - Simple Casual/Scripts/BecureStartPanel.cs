using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BecureStartPanel : MonoBehaviour
{
    [SerializeField]
    GameObject StartButton;
    [SerializeField]
    GameObject Elements;
    [SerializeField]
    GameObject ScreenDim;
    [SerializeField]
    float LeanTime;
    // Start is called before the first frame update
    void Start()
    {
        MoveButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Elements.SetActive(false);

        Image r = ScreenDim.GetComponent<Image>();
        LeanTween.value(ScreenDim, .85f, .0f, LeanTime).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setOnComplete(
            () =>
            {
                gameObject.SetActive(false);
            });

    }

    void MoveButton()
    {
        LeanTween.scale(StartButton, Vector3.one*1.2f, LeanTime).setEaseInOutSine().setLoopPingPong();
    }
}
