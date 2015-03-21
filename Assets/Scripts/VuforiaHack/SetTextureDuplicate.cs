using UnityEngine;
using System.Collections;

public class SetTextureDuplicate : MonoBehaviour {

    RenderTexture rt;

    float delay = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;

        if (delay < 0)
        {
            Vector3 newPos = new Vector3(this.transform.localPosition.x,this.transform.localPosition.y,this.transform.localPosition.z + 100f);

            GameObject newPlane = (GameObject)GameObject.Instantiate(this.gameObject, Vector3.zero, this.transform.localRotation);
            newPlane.transform.parent = this.transform.parent;
            newPlane.transform.localPosition = newPos;
            newPlane.transform.localRotation = this.transform.localRotation;
            newPlane.AddComponent<SetTexture>();
            newPlane.GetComponent<SetTextureDuplicate>().enabled = false;
            newPlane.GetComponent<Vuforia.BackgroundPlaneBehaviour>().enabled = false;
            this.enabled = false;
          
        }

	}
}
