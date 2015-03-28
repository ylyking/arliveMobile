using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PreventClickOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler  {

    private ScrollRect sr;
    private CanvasGroup cg;

    void Awake()
    {
        sr = this.GetComponent<ScrollRect>();
        cg = this.GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData data)
    {
        cg.interactable = false;
    }

    public void OnDrag(PointerEventData data)
    {
   
    }

    public void OnEndDrag(PointerEventData data)
    {
        cg.interactable = true;

    }

}
