using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player 1");
        gameObject.GetComponent<CinemachineCameraOffset>().VirtualCamera.Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
