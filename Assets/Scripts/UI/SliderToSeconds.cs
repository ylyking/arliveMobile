using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderToSeconds : MonoBehaviour {

    public Text secondsText;

    void Start()
    {
        this.GetComponent<Slider>().onValueChanged.AddListener((value) => Change(value));
    }

    public void Change(float str)
    {
        secondsText.text = str.ToString() + " seconds"; 
    }

}
