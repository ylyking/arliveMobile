using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RealTimeView : MonoBehaviour {


    public NetworkView nView;

    public static RealTimeView rtv;
    public string currentDirection = "";
    public bool directionActive = false;

    public Toggle onToggle;
    public Toggle offToggle;

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

    public void ChangeSwitchRTV()
    {
        ToggleGraphics();
        nView.RPC("ChangeSwitch", RPCMode.All, true);
    }

    public void ToggleGraphics()
    {
        StartCoroutine("ChangeToggleGraphics");

    }
     IEnumerator ChangeToggleGraphics()
    {
        yield return new WaitForSeconds(0.2f);
        if (ActionManager.am.lightOn)
        {
            onToggle.isOn = true;
            offToggle.isOn = false;
        }
        else if (!ActionManager.am.lightOn) {
            onToggle.isOn = false;
            offToggle.isOn = true;
        }
       
    }
}
