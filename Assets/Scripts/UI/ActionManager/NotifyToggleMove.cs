using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NotifyToggleMove: MonoBehaviour
{
    public string moveType = "none";

    void Start()
    {
        this.GetComponent<Toggle>().onValueChanged.AddListener((value) => Change(value));
    }

    public void Change(bool isOn)
    {
        if(isOn)  ActionManager.am.moveType = moveType;
    }

}
