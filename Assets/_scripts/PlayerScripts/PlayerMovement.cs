using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float player_movement_speed = 2f;
    private Rigidbody2D player_body;

    public void Awake()
    {
        player_body = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        playerMove();
    }

    public void playerMove()
    {

       // Vector2 horizontal_value = new Vector2();

        if(Input.GetAxisRaw("Horizontal")>0)
        {
            player_body.velocity=new Vector2(player_movement_speed,player_body.velocity.y);
        }


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            player_body.velocity = new Vector2(-player_movement_speed, player_body.velocity.y);
        }
    }


    public void PlatformMove(float _x)
    {
        player_body.velocity = new Vector2(_x,player_body.velocity.y);
    }

   


}
