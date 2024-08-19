using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BecureScorePanel : MonoBehaviour
{
    [SerializeField]
    TMP_Text ScoreValueText;
    [SerializeField]
    TMP_Text HeartValueText;
    [SerializeField]
    TMP_Text TimeValueText;



    [SerializeField]
    GameObject ScoreIMG;
    [SerializeField]
    GameObject HeartIMG;
    [SerializeField]
    GameObject TimeIMG;


    int _Score;
    int _Heart;
    int _Time;


    void Start()
    {
        _Heart = 3;
    }

    public void AddScore(int score)
    {
        _Score += score;
        ScoreValueText.text = (_Score).ToString() ;
        UIManager.Instance.AddCoinFX();
        Beat(ScoreIMG);
    }

    public void AddHeart(int heart)
    {
        _Heart += heart;
        HeartValueText.text = (_Heart).ToString();
        Beat(HeartIMG);
    }

    void Beat(GameObject gameObject)
    {
        
        LeanTween.scale(gameObject, Vector3.one*1.2f, .2f).setEase(LeanTweenType.easeOutQuart).setOnComplete(
       () =>
       {
           LeanTween.scale(gameObject, Vector3.one, .1f).setEase(LeanTweenType.easeOutQuart);
       });
    }
}
