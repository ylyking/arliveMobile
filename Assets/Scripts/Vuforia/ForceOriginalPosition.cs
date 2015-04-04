using UnityEngine;
using System.Collections;

public class ForceOriginalPosition : MonoBehaviour {

    Vector3 originalPosition;
    Quaternion originalRotation;

    void Start()
    {
        originalPosition = this.transform.position;
        originalRotation = this.transform.rotation;
            ;
    }
	
	void Update ()
	{
        this.transform.position = originalPosition;
        this.transform.rotation = originalRotation;
}
}
