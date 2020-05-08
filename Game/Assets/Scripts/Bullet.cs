using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 20f;
    public float damage = 25f;
    public Rigidbody2D iRigidbody;
    public bool isFlipped;

    void Start()
    {
        if (FindObjectOfType<MovementScript>().facingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            iRigidbody.velocity = new Vector3(-1, 0, 0) * speed;
            Debug.Log("I'm Flipped");

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            iRigidbody.velocity = new Vector3(1, 0, 0) * speed;
            Debug.Log("I'm Not");
        }

        
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
       Enemy enemy = hitInfo.GetComponent<Enemy>();
            if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}

