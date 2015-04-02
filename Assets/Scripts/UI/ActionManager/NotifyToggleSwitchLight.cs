using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NotifyToggleSwitchLight : MonoBehaviour
{

    void Start()
    {
        this.GetComponent<Toggle>().onValueChanged.AddListener((value) => Change(value));
    }

    public void Change(bool newVal)
    {
        if (newVal != ActionManager.am.lightOn)
        {
            RealTimeView.rtv.ChangeSwitchRTV();
        }
    }

}
