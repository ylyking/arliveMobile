using UnityEngine;
using System.Collections;

public class KeepTransform : MonoBehaviour {


    public Transform ikTarget;
    public Transform lampTarget;

    private Vector3 originalPos;

    public bool keepLookTarget = true;
    public Transform lampBulbOrigin;

    void Awake()
    {
        originalPos = ikTarget.position - lampTarget.position;   
    }

	void Update ()
	{
        CalculateIkPosition();
        if (keepLookTarget) LookAtTarget();
    }

    void CalculateIkPosition()
    {
        Vector3 newPos = lampTarget.position + originalPos;
        ikTarget.position = newPos;

        ikTarget.rotation = lampTarget.rotation;
    }

    void LookAtTarget()
    {
        Vector3 lookDirection = lampTarget.position - lampBulbOrigin.position;
        Vector3 newVirtualPoint = ikTarget.position + lookDirection;
       // ikTarget.LookAt(newVirtualPoint);

    }
}
