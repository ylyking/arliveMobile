using UnityEngine;
using System.Collections;

public class DebugAll : MonoBehaviour {


    public string objName = "name";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "Root"))
        {
            DebugRoot();
        }

        if (GUI.Button(new Rect(10, 120, 150, 100), "comp"))
        {
            FindCOmponents();
        }
        objName = GUI.TextField(new Rect(10, 230, 200, 20), objName, 25);

    }

    void FindCOmponents()
    {
        Component[] allComponents;
     allComponents = GameObject.Find("BackgroundPlane").GetComponents<Component>();

    foreach (Component co in allComponents)
    {
        DebugConsole.Log(co.GetType().ToString());
    }

    }

    void DebugRoot()
    {
        DebugConsole.Log("----- Debug root -----");
        foreach (GameObject go in Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (go.transform.parent == null && go.transform.parent != this.transform)
            {
                DebugDeeper(go.transform);
            }
        }
    }

    void DebugDeeper(Transform trans)
    {
        int children = trans.GetChildCount();

        if (trans.parent != null && trans.parent.name != "DebugGUI(0)")
            DebugConsole.Log(trans.name + " has " + children);

        for (int child = 0; child < children; child++)
        {
            DebugDeeper(trans.GetChild(child));
        }
    }
}
