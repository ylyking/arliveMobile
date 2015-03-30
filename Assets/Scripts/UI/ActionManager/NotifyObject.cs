using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NotifyObject : MonoBehaviour
{
    public ActionManager.SelectedObject thisObject;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => Change());
    }

    public void Change()
    {
        ActionManager.am.selectedObject = thisObject;
    }

}
