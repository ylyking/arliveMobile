using UnityEngine;
using System.Collections;

public class NetworkFunctions : MonoBehaviour {

    [RPC]
    void SendStringData(string url)
    {
        Debug.Log("Url send");
    }

    [RPC]
    void SendColorData(Vector3 color)
    {
        Debug.Log("Color send");
    }

    [RPC]
    void SendBlinkData(Vector3 blinkData)
    {
        Debug.Log("Send blink data");
    }
}
