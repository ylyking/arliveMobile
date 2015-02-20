using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {


    public Transform targetLamp;
	
	void Update ()
	{
        //look base to target
        Vector3 targetToLook = new Vector3(-targetLamp.position.x * 5, transform.position.y, -targetLamp.position.z* 5);
      //   targetToLook = new Vector3(targetLamp.position.x, transform.position.y, targetLamp.position.z);
        Debug.DrawRay(targetToLook, Vector3.up, Color.green);

        this.transform.LookAt(targetToLook);
	}
}
