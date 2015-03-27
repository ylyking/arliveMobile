using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResizeCanvasAndroid : MonoBehaviour {
    public CanvasScaler can;

	void Start ()
	{
	#if UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android) can.scaleFactor = 1.0f;
    #endif

	}
	
	void Update ()
	{
	
	}
}
