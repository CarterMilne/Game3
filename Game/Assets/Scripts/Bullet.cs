using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 20f;
    public float damage = 40f;
    public Rigidbody2D iRigidbody;

    void Start()
    {
        iRigidbody.velocity = transform.right * speed;
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

