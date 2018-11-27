using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if(PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Loadarena is being called because a player joined");
            LoadArena();
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Loadarena is being called because a player left");
            LoadArena();
        }
    }

    void LoadArena()
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            Debug.Log("The player itself doesnt need to load a level, the 'server/player hosting this game does'");
        }
        Debug.Log("Loading deathmatch");
        PhotonNetwork.LoadLevel("DeathMatch");
    }
}
