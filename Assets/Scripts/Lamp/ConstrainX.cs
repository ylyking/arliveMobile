using UnityEngine;
using System.Collections;

public class ConstrainX : MonoBehaviour {
    public float value;
	
	void Update ()
	{
        this.transform.position = new Vector3(value, this.transform.position.y, this.transform.position.z);
	}
}
