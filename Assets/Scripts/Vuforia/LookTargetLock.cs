using UnityEngine;
using System.Collections;

public class LookTargetLock : MonoBehaviour {

    public Transform camTransform;

	
	void Update ()
	{
        Vector3 newRotation = new Vector3(-camTransform.position.x, transform.position.y, -camTransform.position.z);

        this.transform.LookAt(newRotation);
	}
}
