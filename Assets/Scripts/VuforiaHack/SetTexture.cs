using UnityEngine;
using System.Collections;

public class SetTexture : MonoBehaviour {

    RenderTexture rt;

    float delay = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*
        delay -= Time.deltaTime;
        rt = GameObject.Find("TextureBufferCamera").camera.targetTexture;

        if (delay < 0)
        {

            if (rt != null)
            {
                this.renderer.material.mainTexture = rt;
                //  this.enabled = false;
              //  this.GetComponent<Vuforia.BackgroundPlaneBehaviour>().enabled = false;
            }
        }
        */
	}
}
