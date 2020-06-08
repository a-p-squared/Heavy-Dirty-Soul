using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : MonoBehaviour
{
    public int PlayerID;
    public float Health = 100f;
    public Rigidbody2D Player;
    public Collider2D Collision;
    public float HorizontalDirection;
    public float VerticalDirection;
    float Speed = 130f;
    int RotationDirection = 0;
    public Vector2 NewPosition;
    bool isRepelling = false;
    int RepelTimer = 0;

    int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalDirection = Input.GetAxis("Horizontal");
        VerticalDirection = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.J))
            RotationDirection = -1;
        if (Input.GetKeyUp(KeyCode.J))
            RotationDirection = 0;
        if (Input.GetKeyDown(KeyCode.L))
            RotationDirection = 1;
        if (Input.GetKeyUp(KeyCode.L))
            RotationDirection = 0;

        if (RepelTimer > 0)
            RepelTimer--;
        if (RepelTimer == 0)
            isRepelling = false;

    }

    void FixedUpdate()
    {
        if(!isRepelling)
            Player.velocity = new Vector2 (HorizontalDirection * Speed * Time.deltaTime, VerticalDirection * Speed * Time.deltaTime);
        if (RotationDirection != 0)
            Rotation();
    }

    void Rotation()
    {
        if(RotationDirection == -1)
            Player.transform.Rotate(0, 0, 3);
        if(RotationDirection == 1)
            Player.transform.Rotate(0, 0, -3);
    }

    public void UpdatePosition(Vector2 Position)
    {
        if (!isRepelling)
        {
            isRepelling = true;
            NewPosition = Position;
            if (NewPosition.x >= 0)
                HorizontalDirection = -1;
            else
                HorizontalDirection = 1;
            if (NewPosition.y >= 0)
                VerticalDirection = -1;
            else
                VerticalDirection = 1;
            if (Player.position != NewPosition)
            {
                Player.velocity = new Vector2(HorizontalDirection * Speed * Time.deltaTime, VerticalDirection * Speed * Time.deltaTime);
            }
            RepelTimer = 20;
        }
        else
        {
            RepelTimer = 0;
            isRepelling = false;
            UpdatePosition(Position);
        }

    }

    public void UpdateScore(int ScoreValue)
    {
        Score = Score + ScoreValue;
        Debug.Log(Score);
    }

}
