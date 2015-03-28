using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollRectBlured : MonoBehaviour {

    ScrollRect scrollRect;

    public UnityEngine.UI.Image startBlur;
    public UnityEngine.UI.Image endBlur;
    float globalSpeed = 50.0f;

	void Start ()
	{
        scrollRect = this.GetComponent<ScrollRect>();
        startBlur.enabled = false;
        endBlur.enabled = false;

	}
	
	void Update ()
	{
        float currentPos = 0.0f;

        if (scrollRect.vertical) currentPos = scrollRect.verticalNormalizedPosition;
        else if (scrollRect.horizontal) currentPos = scrollRect.horizontalNormalizedPosition;
        Debug.Log(currentPos);

        if (RoughlyEqual(currentPos, 1.0f) || currentPos > 1.0f)
        {
            startBlur.enabled = false;
            endBlur.enabled = true;
        }
        else if (RoughlyEqual(currentPos, 0.0f) || currentPos < 0.0f)
        {
            startBlur.enabled = true;
            endBlur.enabled = false;
        }
        else
        {
            startBlur.enabled = true;
            endBlur.enabled = true;
        }
      
	}

    public IEnumerator FadeTo(UnityEngine.UI.Image img, float value, float speed)
    {
        float alpha = img.color.a;
        Debug.Log(alpha);
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / speed)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, value, t));
            transform.renderer.material.color = newColor;
            yield return null;
        }
    }

    static bool RoughlyEqual(float a, float b)
    {
        float treshold = 0.02f; //how much roughly
        return (Mathf.Abs(a - b) < treshold);
    }
}
