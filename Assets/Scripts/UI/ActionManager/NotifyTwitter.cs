using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NotifyTwitter : MonoBehaviour
{
    public ActionManager.SocialTriggers thisAction;

    void Start()
    {
        this.GetComponent<Toggle>().onValueChanged.AddListener((value) => Change(value));
    }

    public void Change(bool str)
    {
        ActionManager.am.socialTrigger = thisAction;
    }

}
