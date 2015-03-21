using UnityEngine;
using System.Collections;

public class StereoscopyHack : MonoBehaviour
{

    float delay = 1f;

    void Update()
    {
        delay -= Time.deltaTime;
        if (delay < 0)
        {
            GameObject bCamGo = GameObject.Find("BackgroundCamera(Clone)");
            if (bCamGo != null)
            {
                GameObject plane = bCamGo.transform.GetChild(0).gameObject;
                plane.transform.localScale = new Vector3(.5f, 0, plane.transform.localScale.z);
                plane.transform.localPosition = new Vector3(-.5f, 0, plane.transform.localPosition.z);
                GameObject newPlane = Instantiate(plane) as GameObject;
                StartCoroutine(FixPlane(plane, bCamGo));
                delay = 999999;
            }
        }
    }

    IEnumerator FixPlane(GameObject plane, GameObject bCamGo)
    {
        yield return new WaitForSeconds(.1f);
        GameObject newPlane = GameObject.Find("Plane(Clone)");
        newPlane.transform.parent = bCamGo.transform;
        newPlane.transform.localScale = new Vector3(.5f, 0, plane.transform.localScale.z);
        newPlane.transform.localRotation = plane.transform.localRotation;
        newPlane.transform.localPosition = plane.transform.localPosition;
        newPlane.transform.localPosition += Vector3.right;
        this.enabled = false;
    }
}