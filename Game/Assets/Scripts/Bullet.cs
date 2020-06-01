using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 12.5f;
    // speed variable for the speed of the bullet 
    public float damage = 20f;
    // the damage set for the bullet 
    public Rigidbody2D iRigidbody;
    // the rigidbody giving the bullet physics
    public bool isFlipped;
    // flipping the bullet boolean 

    void Start()
    {
        if (FindObjectOfType<MovementScript>().facingLeft)
            // this is finding the movement script
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            iRigidbody.velocity = new Vector3(-1, 0, 0) * speed;
            Debug.Log("I'm Flipped");
            // flipping thebullet using the quaternions
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            iRigidbody.velocity = new Vector3(1, 0, 0) * speed;
            Debug.Log("I'm Not");
            // flipping thebullet using the quaternions
        }


    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
       Enemy enemy = hitInfo.GetComponent<Enemy>();
        // finds the enemy component
            if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);

        PrisonerHealth prisoner = hitInfo.GetComponent<PrisonerHealth>();
        // finds the enemy component
        if (prisoner != null)
        {
            prisoner.TakeDamage(damage);
        }
        Destroy(gameObject);

        Boss boss = hitInfo.GetComponent<Boss>();
        // finds the enemy component
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}

