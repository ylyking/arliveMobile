using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NotifySliderBlinkRate : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Slider>().onValueChanged.AddListener((value) => Change(value));
    }

    public void Change(float val)
    {
        ActionManager.am.blinkRate = val;
    }


}
