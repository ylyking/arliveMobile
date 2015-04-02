using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeColorGridRealTime : MonoBehaviour {
	
	void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => ChangeColor());
    }


	public void ChangeColor ()
	{
        Color newColor =  this.GetComponent<Button>().image.color;
        Vector3 vectoColor = new Vector3(newColor.r, newColor.g, newColor.b);
        RealTimeView.rtv.ChangeRealTimeColor(vectoColor);
	}
}
