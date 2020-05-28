using System.Collections;
using System.Collections.Generic;
using MLAPI;
using MLAPI.SceneManagement;
using UnityEngine;

public class HostGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            NetworkingManager.Singleton.OnClientConnectedCallback += ClientConnected;
            NetworkingManager.Singleton.OnClientDisconnectCallback += ClientDisconnected;
            NetworkingManager.Singleton.OnServerStarted += () => {
                Debug.Log("Server started");
                CreateServerEnvironment();
            };
            NetworkingManager.Singleton.StartServer();
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            NetworkingManager.Singleton.OnClientConnectedCallback += ClientConnected;
            NetworkingManager.Singleton.OnClientDisconnectCallback += ClientDisconnected;
            NetworkingManager.Singleton.StartClient();
        }
    }
    
    private void CreateServerEnvironment() {
        var progress = NetworkSceneManager.SwitchScene("InteractionScene");
        progress.OnClientLoadedScene += id => {
            Debug.Log("client " + id + "has changed scene");
        };
    }

    private void ClientConnected(ulong clientId) {
        Debug.Log($"I'm connected {clientId}");
    }

    private void ClientDisconnected(ulong clientId) {
        Debug.Log($"I'm disconnected {clientId}");
    }
}
