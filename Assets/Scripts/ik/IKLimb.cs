using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class IKLimb: MonoBehaviour {
	public Transform baseObj, upperArm, forearm, hand;
    public Transform target, elbowTarget, targetLamp;
	
	public bool IsEnabled, debug;
	
	public float transition = 1.0f;
	
	public bool idleOptimization = false;
	
	public enum HandRotations {
		KeepLocalRotation,
		KeepGlobalRotation,
        UseTargetRotation,
    	LookAtTarget
};
	public HandRotations handRotationPolicy = HandRotations.KeepLocalRotation;
	
	private Quaternion upperArmStartRotation, forearmStartRotation, handStartRotation;
	private Vector3 targetRelativeStartPosition, elbowTargetRelativeStartPosition;
	
	//helper GOs that are reused every frame
	private GameObject upperArmAxisCorrection, forearmAxisCorrection, handAxisCorrection;
	
	//hold last positions so recalculation is only done if needed
	private Vector3 lastUpperArmPosition, lastTargetPosition, lastElbowTargetPosition;


    public bool invertElbow = true;
    public bool elbowAligned = false;

    public Vector3 customRotation = Vector3.zero;


	void Start()
    {
		upperArmStartRotation = upperArm.rotation;
		forearmStartRotation = forearm.rotation;
		handStartRotation = hand.rotation;
		//targetRelativeStartPosition = target.position - upperArm.position;
		elbowTargetRelativeStartPosition = elbowTarget.position - upperArm.position;
		
		//create helper GOs
		upperArmAxisCorrection = new GameObject("upperArmAxisCorrection_helper");
        forearmAxisCorrection = new GameObject("forearmAxisCorrection_helper");
        handAxisCorrection = new GameObject("handAxisCorrection_helper");
		
		//set helper hierarchy
		upperArmAxisCorrection.transform.parent = transform;
		forearmAxisCorrection.transform.parent = upperArmAxisCorrection.transform;
		handAxisCorrection.transform.parent = forearmAxisCorrection.transform;
		
		//guarantee first-frame update
		lastUpperArmPosition = upperArm.position + 5*Vector3.up;
	}
	
	void LateUpdate ()
    {
		if (!IsEnabled){
			return;
		}
		CalculateIK();
	}
	
	void CalculateIK()
    {
		if(target == null)
        {
			targetRelativeStartPosition = Vector3.zero;
			return;
		}
		
		if(targetRelativeStartPosition == Vector3.zero && target != null)
        {
			targetRelativeStartPosition = target.position - upperArm.position;
		}
			
		if(
			idleOptimization
				&&
			lastUpperArmPosition == upperArm.position
				&&
			lastTargetPosition == target.position
				&&
			lastElbowTargetPosition == elbowTarget.position
		)
        {
			if(debug)
            {
				Debug.DrawLine(forearm.position, elbowTarget.position, Color.yellow);
				Debug.DrawLine(upperArm.position, target.position, Color.red);
			}
			
			return;
		}


        //look base to target
        Vector3 handFore = hand.position - forearm.position;
        Vector3 targetToLook = new Vector3(-targetLamp.position.x - handFore.x * 2, baseObj.position.y, -targetLamp.position.z - handFore.z * 2);
        baseObj.LookAt(targetToLook);

		lastUpperArmPosition = upperArm.position;
		lastTargetPosition = target.position;
		lastElbowTargetPosition = elbowTarget.position;
	
		//Calculate ikAngle variable.
		float upperArmLength = Vector3.Distance(upperArm.position, forearm.position);
		float forearmLength = Vector3.Distance(forearm.position, hand.position);
		float armLength = upperArmLength + forearmLength;
		float hypotenuse = upperArmLength;
		
		float targetDistance = Vector3.Distance(upperArm.position, target.position);	
		targetDistance = Mathf.Min(targetDistance, armLength - 0.0001f); //Do not allow target distance be further away than the arm's length.
		
		//var adjacent : float = (targetDistance * hypotenuse) / armLength;
		//var adjacent : float = (Mathf.Pow(hypotenuse,2) - Mathf.Pow(forearmLength,2) + Mathf.Pow(targetDistance,2))/(2*targetDistance);
		float adjacent = (hypotenuse*hypotenuse - forearmLength*forearmLength + targetDistance*targetDistance) /(2*targetDistance);
		
		float ikAngle  = Mathf.Acos(adjacent/hypotenuse) * Mathf.Rad2Deg;
		
		//Store pre-ik info.
		Vector3 targetPosition = target.position;
		Vector3 elbowTargetPosition = elbowTarget.position;
		
		Transform upperArmParent = upperArm.parent;
		Transform forearmParent = forearm.parent;
		Transform handParent = hand.parent; 
		
		Vector3 upperArmScale = upperArm.localScale;
		Vector3 forearmScale = forearm.localScale;
		Vector3 handScale = hand.localScale;
		Vector3 upperArmLocalPosition = upperArm.localPosition;
		Vector3 forearmLocalPosition = forearm.localPosition;
		Vector3 handLocalPosition = hand.localPosition;
		
		Quaternion upperArmRotation = upperArm.rotation;
		Quaternion forearmRotation = forearm.rotation;
		Quaternion handRotation = hand.rotation;
		Quaternion handLocalRotation = hand.localRotation;
		
		//Reset arm.
		target.position = targetRelativeStartPosition + upperArm.position;
		elbowTarget.position = elbowTargetRelativeStartPosition + upperArm.position;
		upperArm.rotation = upperArmStartRotation;
		forearm.rotation = forearmStartRotation;
		hand.rotation = handStartRotation;
		
		//Work with temporaty game objects and align & parent them to the arm.
		transform.position = upperArm.position;
		transform.LookAt(targetPosition, elbowTargetPosition - transform.position);
		
		upperArmAxisCorrection.transform.position = upperArm.position;
		//upperArmAxisCorrection.transform.LookAt(forearm.position, transform.root.up);

        ///constrain
		upperArmAxisCorrection.transform.LookAt(forearm.position, upperArm.up);
       
     ///   Vector3 lookForearm = new Vector3(upperArmAxisCorrection.transform.position.x, upperArmAxisCorrection.transform.position.y, forearm.position.z);
       // lookForearm = upperArmAxisCorrection.transform.position;
      //  upperArmAxisCorrection.transform.LookAt(lookForearm, upperArm.up);



		upperArm.parent = upperArmAxisCorrection.transform;
		
		forearmAxisCorrection.transform.position = forearm.position;
		//forearmAxisCorrection.transform.LookAt(hand.position, transform.root.up);
		forearmAxisCorrection.transform.LookAt(hand.position, forearm.up);
		forearm.parent = forearmAxisCorrection.transform;
		
		handAxisCorrection.transform.position = hand.position;
		hand.parent = handAxisCorrection.transform;
		
		//Reset targets.
		target.position = targetPosition;
		elbowTarget.position = elbowTargetPosition;	
		
		//Apply rotation for temporary game objects.
		upperArmAxisCorrection.transform.LookAt(target,elbowTarget.position - upperArmAxisCorrection.transform.position);
        //// lock on one axi
     //   upperArmAxisCorrection.transform.localRotation = Quaternion.Euler(upperArmAxisCorrection.transform.localEulerAngles.x, 0, 0);
       //// upperArmAxisCorrection.transform.rotation = Quaternion.Euler(0, 0, 0);



        if (!float.IsNaN(ikAngle))
        {
            Vector3 newRotation = upperArmAxisCorrection.transform.localRotation.eulerAngles - new Vector3(ikAngle, 0, 0);
            newRotation = new Vector3(newRotation.x, 0, newRotation.z);
            upperArmAxisCorrection.transform.localRotation = Quaternion.Euler(newRotation);

            //test upperArmStartRotation.eulerAngles.y
         //   upperArmAxisCorrection.transform.localRotation = Quaternion.Euler(upperArmAxisCorrection.transform.localRotation.x, upperArmAxisCorrection.transform.localRotation.y, upperArmAxisCorrection.transform.localRotation.z);
        }

		forearmAxisCorrection.transform.LookAt(target,elbowTarget.position - upperArmAxisCorrection.transform.position);
		handAxisCorrection.transform.rotation = target.rotation;

        //forearm correction
        forearmAxisCorrection.transform.position = new Vector3(0, forearmAxisCorrection.transform.position.y, forearmAxisCorrection.transform.position.z);
        forearm.transform.position = new Vector3(0, forearm.transform.position.y, forearm.transform.position.z);

		//Restore limbs.
		upperArm.parent = upperArmParent;
		forearm.parent = forearmParent;
		hand.parent = handParent;
		upperArm.localScale = upperArmScale;
		forearm.localScale = forearmScale;
		hand.localScale = handScale;
		upperArm.localPosition = upperArmLocalPosition;
		forearm.localPosition = forearmLocalPosition;
		hand.localPosition = handLocalPosition;
		
		//Transition.
		transition = Mathf.Clamp01(transition);
        upperArm.rotation = Quaternion.Slerp(upperArmRotation, upperArm.rotation, transition);
		forearm.rotation = Quaternion.Slerp(forearmRotation, forearm.rotation, transition);
		//hand.rotation = Quaternion.Slerp(handRotation, hand.rotation, transition);
		
		switch(handRotationPolicy)
        {
		case HandRotations.KeepLocalRotation:
			hand.localRotation = handLocalRotation;
			
			break;
		case HandRotations.KeepGlobalRotation:
			hand.rotation = handRotation;
			
			break;
		case HandRotations.UseTargetRotation:
			hand.rotation = target.rotation;
		
			break;

         case HandRotations.LookAtTarget:

            break;
		}
			
		//Debug.
		if (debug)
        {
			Debug.DrawLine(forearm.position, elbowTarget.position, Color.yellow);
			Debug.DrawLine(upperArm.position, target.position, Color.red);
				
			Debug.Log("[IK Limb] adjacent: " + adjacent);
		}

        if (invertElbow) InvertEl();
        if (elbowAligned) AlignEl();

    //    upperArm.transform.Rotate(customRotation);

	}

    void AlignEl()
    {

        Vector3 targetForearmDifference = target.position - new Vector3(0, forearm.transform.position.y, forearm.transform.position.z);

        Vector3 newElPosition = forearm.transform.position - targetForearmDifference;

        elbowTarget.transform.position = newElPosition;
    }

    void InvertEl()
    {

        Vector3 targetForearmDifference = target.position - new Vector3(0,forearm.transform.position.y,forearm.transform.position.z);

        Vector3 newElPosition = forearm.transform.position - targetForearmDifference;

        elbowTarget.transform.position = newElPosition;
    }
}
