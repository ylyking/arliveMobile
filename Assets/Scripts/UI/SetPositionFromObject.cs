using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]

public class SetPositionFromObject : MonoBehaviour
{

    public Canvas can;
    public Camera cam;


    public GameObject WorldObject;

    public RectTransform UI_Element;
    RectTransform CanvasRect;

    void Start()
    {
        CanvasRect = can.GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 ViewportPosition = cam.WorldToViewportPoint(WorldObject.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) * cam.rect.width - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) * cam.rect.height - (CanvasRect.sizeDelta.y * 0.5f))
        );


        UI_Element.anchoredPosition = WorldObject_ScreenPosition;

    }
}