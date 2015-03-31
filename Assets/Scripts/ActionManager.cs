using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour {

    public static ActionManager am;
    public NetworkView nView;

    public enum Steps
    {
        START,
        SERVICE,
        OBJECT,
        ACTION,
        DONE
    }

    public enum SocialTriggers
    {
        NONE,
        MENTION,
        HASHTAG
    }

    public enum SelectedObject
    {
        NONE,
        LAMP,
        SWITCH
    }

    public enum Action
    {
        NONE,
        CHANGECOLOR,
        MOVE,
        NOTIFY
    }

    public string socialString = null;
    public int stepCount = 0;
    public SocialTriggers socialTrigger = SocialTriggers.NONE;
    public SelectedObject selectedObject = SelectedObject.NONE;
    public Action action = Action.NONE;
    public Color lightColor;
    public float blinkDuration = 0;
    public float blinkRate = 0;

    public Steps currentStep = Steps.START;

    public GameObject UiCreate;
    public GameObject UiHeader;
    public GameObject UiNewService;
    public GameObject UiNewObject;
    public GameObject UiSelectAction;
    public GameObject UiDetailedObject;
    public GameObject UiSucessCreate;

    public GameObject[] UiSteps;

    void Start()
    {
        am = this;
    }
    public void StartAction(string type)
    {
        Reset();
       // Done();

       if(type == "service")
       {
           currentStep = Steps.SERVICE;
       }
       else if(type == "object")
       {
           currentStep = Steps.OBJECT;
       }
       stepCount++;
       ActivateUi();
    }

    public void NextStep()
    {

        if (stepCount == 3)
        {
            currentStep = Steps.DONE;
        }
        else
        {
            switch (currentStep)
            {
                case Steps.SERVICE:
                    currentStep = Steps.OBJECT;
                    stepCount++;
                    break;
                case Steps.OBJECT:
                    currentStep = Steps.ACTION;
                    stepCount++;
                    break;
                case Steps.ACTION:
                    if (stepCount == 2)
                    {
                        currentStep = Steps.SERVICE;
                        stepCount++;
                    }
                    break;
                case Steps.DONE:
                    break;

            }

        }
        ActivateUi();
    }

    void ActivateUi()
    {
        //DisableGraphics();
        UiCreate.SetActive(true);
        switch(currentStep)
        {
            case Steps.START:
                UiCreate.SetActive(false);
                break;
            case Steps.SERVICE:
                DisableGraphics();
                UiNewService.SetActive(true);
                break;
            case Steps.OBJECT:
                 DisableGraphics();
                 UiNewObject.SetActive(true);
                break;
            case Steps.ACTION:
                DisableGraphics();
                UiSelectAction.SetActive(true);
                break;
            case Steps.DONE:
                UiDetailedObject.SetActive(true);
                UiSucessCreate.SetActive(true);
                UiCreate.SetActive(false);
                Done();
                break;
        }

        ToggleSteps();
    }

    void ToggleSteps()
    {
        for(int i = 0; i < UiSteps.Length; i++)
        {
            if (i == (stepCount - 1)) UiSteps[i].SetActive(true);
            else UiSteps[i].SetActive(false);
        }
    }
    void Done()
    {
        //Send URL
        string argumentsURL = "type=";
        
        if (socialTrigger == SocialTriggers.HASHTAG)  argumentsURL += "hashtag&string=" + socialString;
        else if (socialTrigger == SocialTriggers.MENTION) argumentsURL += "mention";

        nView.RPC("SendStringData", RPCMode.All, argumentsURL);

        //Send Color
        Vector3 colorVector = new Vector3(lightColor.r, lightColor.g, lightColor.b);
        nView.RPC("SendColorData", RPCMode.All, colorVector);

        //send blink
        Vector3 blinkVector = new Vector3(blinkDuration, blinkRate, 0.0f);
        nView.RPC("SendBlinkData", RPCMode.All, blinkVector);

        Reset();
    }

    public void Reset()
    {
        socialString = null;
        stepCount = 0;
        socialTrigger = SocialTriggers.NONE;
        selectedObject = SelectedObject.NONE;
        action = Action.NONE;
        currentStep = Steps.START;

        ActivateUi();
        DisableGraphics();
    }

    void DisableGraphics()
    {
        UiHeader.transform.parent.GetComponent<ToggleAll>().SetActiveAll(false);
    }

   
}
