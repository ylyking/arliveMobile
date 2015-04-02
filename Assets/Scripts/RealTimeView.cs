using UnityEngine;
using System.Collections;

public class RealTimeView : MonoBehaviour {


    public NetworkView nView;

    public static RealTimeView rtv;
    public string currentDirection = "";
    public bool directionActive = false;

    void Awake() {
        rtv = this;
    }


    void Update()
    {
        if(directionActive)
        {
             nView.RPC("MoveRealTime", RPCMode.All, currentDirection);
        }
    
    }


    public void RealtTimeEnable(int isActive)
    {
        if (isActive == 1) directionActive = true;
        else
        {
            directionActive = false;
            currentDirection = "";
        }
            nView.RPC("SetRealTime", RPCMode.All, isActive);
    }

    public void MoveDirection(string direction)
    {
        currentDirection = direction;
    }

    public void ChangeRealTimeColor(Vector3 color)
    {
        // 0 = false, 1 = true
        nView.RPC("ColorRealTime", RPCMode.All, color);
    }
}
