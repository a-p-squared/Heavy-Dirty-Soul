using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class LobbyMenu : MonoBehaviourPunCallbacks
{
    GameObject Player;
    public int PlayerId;
    bool startGame = true;
    bool isWaiting = true;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        DontDestroyOnLoad(transform.gameObject);
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("HeavyRoom", null, null, null);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("HeavyRoom", null);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room Created Successfully!");
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
            PlayerId = 1;
        else
            PlayerId = 2;
    }

    private void FixedUpdate()
    {
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            isWaiting = false;
            StartGame();
        }

    }

    private void StartGame()
    {
        if(startGame && !isWaiting)
        {
            SceneManager.LoadScene(3, LoadSceneMode.Single);
            if (PlayerId == 1)
            {
                Player = PhotonNetwork.Instantiate("Player 1", new Vector3(-7f, -6f, 0), Quaternion.identity);
            }
            if (PlayerId == 2)
            {
                Player = PhotonNetwork.Instantiate("Player 1", new Vector3(7f, -6f, 0), Quaternion.identity);
            }

            startGame = false;
        }
    }
}
