using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float moveSpeed = 7f;
    Rigidbody2D iRigidbody;
    MovementScript target;
    Vector2 moveDirection;


    void Start()
    {
        iRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<MovementScript>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        iRigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);    
    }
    
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name =="Man")
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
            target.TakeDamage(10f);
        }
    }
    

}
