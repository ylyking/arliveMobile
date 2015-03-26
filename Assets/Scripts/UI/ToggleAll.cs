using UnityEngine;
using System.Collections;

public class ToggleAll : MonoBehaviour {

    public GameObject[] allObjects;

	
	public void SetActiveAll (bool setA)
	{
        for (int i = 0; i < allObjects.Length; i++)
        {
            allObjects[i].SetActive(setA);
        }
	}

}
