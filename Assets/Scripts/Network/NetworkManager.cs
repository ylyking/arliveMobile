using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    public bool setupServer = false;
    public GameObject networkPopup = null;

	void Start ()
    {
        #if UNITY_EDITOR
      //  setupServer = true;
       #endif

        networkPopup.SetActive(false);

        if (setupServer) CreateServer();
        else ConnectToServer();
	}
	
	void CreateServer ()
	{
        Network.InitializeServer(3, 25000, false);
	}

    public void ConnectToServer()
    {
        if (PlayerPrefs.HasKey("ipAdress"))
        {
            Network.Connect(PlayerPrefs.GetString("ipAdress"), 25000);
            networkPopup.SetActive(false);
        }
        else
        {
            networkPopup.SetActive(true);
        }
    }

    void OnFailedToConnect(NetworkConnectionError error)
    {
        networkPopup.SetActive(true);
        Debug.Log("Could not connect to server: " + error);
    }

    void OnConnectedToServer()
    {
        networkPopup.SetActive(false);
        Debug.Log("Connected to server");
    }

    void OnServerInitialized()
    {
        networkPopup.SetActive(false);
        Debug.Log("Server initialized");
    }

    void OnDisconnectedFromServer()
    {
        networkPopup.SetActive(true);
        Debug.Log("Disconnected from server");
    }

    void OnPlayerConnected()
    {
        Debug.Log("Player connected");
    }

    void OnPlayerDisconnected()
    {
        Debug.Log("Player disconnected");
    }

}
