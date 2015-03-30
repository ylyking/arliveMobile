using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResizeCanvasAndroid : MonoBehaviour {
    public CanvasScaler can;
    public float tabletValue= 1.0f;

	void Start ()
	{
	#if UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android) can.scaleFactor = tabletValue;
    #endif

	}
	
	void Update ()
	{
	
	}
}
