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

    [RPC]
    void SendMoveType(string moveType)
    {
        Debug.Log("Send move type");
    }

    [RPC]
    void SendMoveData(float moveData)
    {
        Debug.Log("Send move data");
    }



    ///RealTimeView
    [RPC]
    void SetRealTime(int isActive)
    {
        Debug.Log("Send real time state");
    }

    [RPC]
    void MoveRealTime(string direction)
    {
        Debug.Log("send real time direction");
    }

    [RPC]
    void ColorRealTime(Vector3 color)
    {
        Debug.Log("send real time color");
    }


}
