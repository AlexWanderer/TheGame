﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// My own network manager, extends from Unitities network
/// </summary>
public class MyNetworkManager : NetworkManager
{
    /// <summary>
    /// This method will start a host client
    /// </summary>
    public void HostGame()
    {
        SetPort();
        singleton.StartHost();
        
        print(singleton.networkAddress);
    }
	
    /// <summary>
    /// Will start a client that will communicate with a server
    /// </summary>
    public void JoinGame()
    {
        SetIPAdress();
        SetPort();

        singleton.StartClient();

        //print("Connected to: " + singleton.networkAddress);
    }

    /// <summary>
    /// Sets the port to connect to
    /// </summary>
    private void SetPort()
    {
        //singleton.networkPort = 7777;
    }

    /// <summary>
    /// Sets the ip address to connect to
    /// </summary>
    private void SetIPAdress()
    {
        var ipAdress = GameObject.Find("InputIP").transform.FindChild("Text").GetComponent<Text>().text;
        singleton.networkAddress = ipAdress;
    }

    /// <summary>
    /// Unity method; called when a level has succesfully loaded
    /// Used to set e
    /// </summary>
    /// <param name="level"></param>
    private void OnLevelWasLoaded(int level)
    {
        if(level == 0)
        {
            //return; // Temporary return statement till I fix the menu buttons
            StartCoroutine(LoadMenuButtons());
            return;
        }
        
        LoadLevelButtons();
    }

    /// <summary>
    /// Loads the listeners for the buttons on the menu screen
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadMenuButtons()
    {
        // Prevents a conflict with network managers on the menu screen
        yield return new WaitForSeconds(0.5f);

        GameObject.Find("button_StartHost").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("button_StartHost").GetComponent<Button>().onClick.AddListener(HostGame);

        GameObject.Find("button_JoinMatch").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("button_JoinMatch").GetComponent<Button>().onClick.AddListener(JoinGame);
    }

    /// <summary>
    /// Loads the listeners for the buttons in game
    /// </summary>
    private void LoadLevelButtons()
    {
        GameObject.Find("button_Disconnect").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("button_Disconnect").GetComponent<Button>().onClick.AddListener(singleton.StopHost);
    }
}