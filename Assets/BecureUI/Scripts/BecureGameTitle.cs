using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecureGameTitle : MonoBehaviour
{

    [SerializeField]
    float MoveDistance;
    [SerializeField]
    float MoveTime;
    // Start is called before the first frame update
    void Start()
    {
        MoveTitle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveTitle()
    {
        LeanTween.moveY(gameObject, transform.position.y - MoveDistance, MoveTime).setEaseInOutSine().setLoopPingPong();
    }
}
