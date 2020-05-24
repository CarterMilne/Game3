using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnakePatrol : MonoBehaviour
{
    public float speed;
    // speed variable that is for the snake speed
    public float distance;
    // the distance variable for the distance between the edge of the floor and the snake
    private bool movingRight = true;
    // the boolean telling the snake to move right at the start of my script
    public Transform groundDetection;
    // calling from the ground dectection in the game
   
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        // this is how to the snake moves in compareion to the speed and position   

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        // this is when the ground detection touches the edge
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                // when it is moving right once reaches the end the snake flips to the left
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
                // when it is moving left once reaches the end the snake flips to the right

            }
        }
    }
}

