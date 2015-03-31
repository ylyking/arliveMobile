using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GotToNextStepIfChecked : MonoBehaviour {


    public Toggle toggleToverify;
    public GameObject popupService;
	
	public void CheckIfChekked ()
	{
        if (toggleToverify.isOn)
        {
            ActionManager.am.NextStep();
            popupService.SetActive(false);
        }
	}
}
