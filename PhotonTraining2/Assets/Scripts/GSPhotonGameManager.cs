using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GSPhotonGameManager : MonoBehaviourPunCallbacks
{
    //Public Variables
    public string sPrefabPlayerName;

    // Start is called before the first frame update
    void Start()
    {
        // Start Photon Network
        PhotonNetwork.ConnectUsingSettings();
    }

    // 1. Function overrider to detect if we have successfully connected to the Master Server
    public override void OnConnectedToMaster()
    {
        // Join Lobby
        PhotonNetwork.JoinLobby();
    }

    // 2. Function overrider to detect if we have successfully connected to the Lobby
    public override void OnJoinedLobby()
    {
        // Join OR Create a room
        PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions { MaxPlayers = 8 }, TypedLobby.Default);
    }

    // 3. Function overrider to detect if we have successfully connected to the Room
    public override void OnJoinedRoom()
    {
        // Instantiate Player
        PhotonNetwork.Instantiate(sPrefabPlayerName, new Vector3(Random.Range(-5.0f, 5.0f), gameObject.transform.position.y, 0.0f), Quaternion.identity);
    }

}
