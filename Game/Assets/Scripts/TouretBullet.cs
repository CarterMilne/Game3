using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouretBullet : MonoBehaviour
{
    float moveSpeed = 15f;
    // this is the movement speed of the bullet
    Rigidbody2D iRigidbody;
    // rigidody
    MovementScript target;
    // the movement script (the player) is the target of the enemies bullet
    Vector2 moveDirection;
    //the move dircetion feature called from the 2 vectors of x and y
    void Start()
    {
        iRigidbody = GetComponent<Rigidbody2D>();
        // the rigdbody geting the componetn from the game
        target = GameObject.FindObjectOfType<MovementScript>();
        // the target of teh attack is the player but called movement script 
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        // the direction of the bullet follows the players current positoion
        iRigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        // the rigidbody of the bullet
        Destroy(gameObject, 1f);
        // after the object has ben instatiated 1 second later it destroys
    }

    void OnTriggerEnter2D(Collider2D col)
    // when the bullet collides with the player
    {
        if (col.gameObject.name == "Man")
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
            // when hit the bullet destroys
            target.TakeDamage(20f);
            // damage is done to the character
        }
    }


}


