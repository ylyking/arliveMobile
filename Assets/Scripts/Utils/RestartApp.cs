using UnityEngine;
using System.Collections;

public class RestartApp : MonoBehaviour {

    public void Restart()
    {
        Application.LoadLevel(0);
    }
}
