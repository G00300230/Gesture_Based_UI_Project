﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    //Hold the playable characters
    public GameObject[] playerCharacters;
    //Hold spawing positions
    public Transform[] spawningPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnJoinedRoom(){

        if(PhotonNetwork.IsConnectedAndReady){
            object playerSelectionNo;
            //Each playable character has a number. Get the players number from 0-3
            if(PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(MultiplayerARSpinnerTopGame.PLAYER_SELECTION_NUMBER, out playerSelectionNo))
            {
                Debug.Log("Player selection number is " + (int)playerSelectionNo);
                int spawnPoint = Random.Range(0, spawningPoints.Length -1);
                //Instantiate position based on random spawn point
                Vector3 instantiatePlayerPosition = spawningPoints[spawnPoint].position;
                //Instantiate the character based on its number
                PhotonNetwork.Instantiate(playerCharacters[(int)playerSelectionNo].name, instantiatePlayerPosition, Quaternion.identity);
            }


        }
    }
}