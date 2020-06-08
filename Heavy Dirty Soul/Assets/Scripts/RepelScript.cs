using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelScript : MonoBehaviour
{
    public GameObject Player;
    public Vector2 NewPosition;
    public int ChangeScore = -10;

    public string PlayerID = "Player 1";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Player = GameObject.FindGameObjectWithTag(PlayerID);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == Player.GetComponent<CapsuleCollider2D>())
        {
            if (Player.transform.position.x > 0 && Player.transform.position.x - 2 != 0)
                NewPosition.x = Player.transform.position.x - 2;
            else
                NewPosition.x = Player.transform.position.x + 2;

            if (Player.transform.position.y > 0 && Player.transform.position.y + 2 != 0)
                NewPosition.y = Player.transform.position.y - 2;
            else
                NewPosition.y = Player.transform.position.y + 2;

            Player.GetComponent<Player1Script>().UpdatePosition(NewPosition);

            Player.GetComponent<Player1Script>().UpdateScore(ChangeScore);
        }
    }

}
