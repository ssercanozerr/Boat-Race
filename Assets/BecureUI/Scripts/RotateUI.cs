using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    RectTransform selfAnchor;
    public float speed;
    float targetRotation =0;
    //Set the rotating elements RectTransform
    void Start()
    {
        selfAnchor = GetComponent<RectTransform>();
    }

    //Update the UI elements rotation
    void LateUpdate()
    {
        targetRotation +=speed;
        selfAnchor.rotation = Quaternion.Euler(0, 0, targetRotation);
    }
}
