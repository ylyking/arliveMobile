using UnityEngine;
using System.Collections;

public class ToggleAll : MonoBehaviour {

    public GameObject[] allObjects;

    public int enableFirst = 10000;
    void OnEnable()
    {
       SetActiveAll(false);
       if (enableFirst < allObjects.Length) allObjects[enableFirst].SetActive(true);
    }

	public void SetActiveAll (bool setA)
	{
        for (int i = 0; i < allObjects.Length; i++)
        {
            allObjects[i].SetActive(setA);
        }
	}

}
