using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollRectBlured : MonoBehaviour {

    ScrollRect scrollRect;

    public UnityEngine.UI.Image startBlur;
    public UnityEngine.UI.Image endBlur;
    float globalSpeed = 0.1f;

	void Awake ()
	{
        scrollRect = this.GetComponent<ScrollRect>();
    }

    void OnEnable()
    {
        float currentPos = 0.0f;

        if (scrollRect.vertical) currentPos = scrollRect.verticalNormalizedPosition;
        else if (scrollRect.horizontal) currentPos = scrollRect.horizontalNormalizedPosition;

        if (RoughlyEqual(currentPos, 1.0f) || currentPos > 1.0f)
        {
            startBlur.CrossFadeAlpha(0.0f, 0.0f, false);
            endBlur.CrossFadeAlpha(1.0f, 0.0f, false);
        }
        else if (RoughlyEqual(currentPos, 0.0f) || currentPos < 0.0f)
        {
            startBlur.CrossFadeAlpha(1.0f, 0.0f, false);
            endBlur.CrossFadeAlpha(0.0f, 0.0f, false);
        }
        else
        {
            startBlur.CrossFadeAlpha(1.0f, 0.0f, false);
            endBlur.CrossFadeAlpha(1.0f, 0.0f, false);
        }
    }
	
	void Update ()
	{
        float currentPos = 0.0f;

        if (scrollRect.vertical) currentPos = scrollRect.verticalNormalizedPosition;
        else if (scrollRect.horizontal) currentPos = scrollRect.horizontalNormalizedPosition;

        if (RoughlyEqual(currentPos, 1.0f) || currentPos > 1.0f)
        {
            //startBlur.enabled = false;
           // endBlur.enabled = true;
            startBlur.CrossFadeAlpha(0.0f, globalSpeed, false);
            endBlur.CrossFadeAlpha(1.0f, globalSpeed, false);

        }
        else if (RoughlyEqual(currentPos, 0.0f) || currentPos < 0.0f)
        {
            //startBlur.enabled = true;
            //endBlur.enabled = false;
            startBlur.CrossFadeAlpha(1.0f, globalSpeed, false);
            endBlur.CrossFadeAlpha(0.0f, globalSpeed, false);

        }
        else
        {
           // startBlur.enabled = true;
            //endBlur.enabled = true;
            startBlur.CrossFadeAlpha(1.0f, globalSpeed, false);
            endBlur.CrossFadeAlpha(1.0f, globalSpeed, false);

        }
      
	}

    static bool RoughlyEqual(float a, float b)
    {
        float treshold = 0.02f; //how much roughly
        return (Mathf.Abs(a - b) < treshold);
    }
}
