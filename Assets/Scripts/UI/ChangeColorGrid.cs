using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeColorGrid : MonoBehaviour {

    public Button colorButtonL;
    public Button colorButtonB;

	
	void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => ChangeColor());
    }


	public void ChangeColor ()
	{
        Color newColor =  this.GetComponent<Button>().image.color;

        colorButtonL.image.color = newColor;
        colorButtonB.image.color = newColor;

        ActionManager.am.lightColor = newColor;
	}
}
