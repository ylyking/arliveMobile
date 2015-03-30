using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NotifyInput : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<InputField>().onValueChange.AddListener((value) => Change(value));
    }

    public void Change(string str)
    {
        ActionManager.am.socialString = str;
    }


}
