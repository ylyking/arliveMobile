using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveIp : MonoBehaviour {

    InputField inputF;
    
	void Awake ()
	{
        inputF = this.GetComponent<InputField>();

        if (PlayerPrefs.HasKey("ipAdress")) inputF.text = PlayerPrefs.GetString("ipAdress");
        else inputF.text = "192.168.1.32";
	}
	
	public void SaveCurrentIp ()
	{
        PlayerPrefs.SetString("ipAdress", inputF.text);
        PlayerPrefs.Save();
        Debug.Log("save current IP");
	}
}
