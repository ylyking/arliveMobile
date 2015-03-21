using UnityEngine;
using System.Collections;

public class WebcamTexture : MonoBehaviour {

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        WebCamTexture webcamTexture = new WebCamTexture();
        if (devices.Length > 0)
        {
            webcamTexture.deviceName = devices[0].name;
            webcamTexture.Play();
            this.renderer.material.mainTexture = webcamTexture;

        }
    }

}
