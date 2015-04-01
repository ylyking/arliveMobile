using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NotifySliderMoveDuration : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Slider>().onValueChanged.AddListener((value) => Change(value));
    }

    public void Change(float val)
    {
        ActionManager.am.moveDuration = val;
    }


}
