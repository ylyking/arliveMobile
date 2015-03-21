using UnityEngine;
using System.Collections;

public class RotateLookAt : MonoBehaviour {

    public Transform ikTarget;
    public Transform lampTarget;

    void Update()
    {
        RotateBase();
    }

    void RotateBase()
    {
        this.transform.LookAt(lampTarget);
        this.transform.localRotation = Quaternion.Euler(0, this.transform.eulerAngles.y, 0);
    }
}
