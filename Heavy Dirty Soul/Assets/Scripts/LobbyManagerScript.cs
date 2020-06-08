using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;

public class LobbyManagerScript : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }
}
