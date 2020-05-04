using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public SpriteRenderer player;
    
    void Start()
    {
        player = transform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot ()
    {
        if (player.flipX)
        {
           GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
           bullet.GetComponent<Bullet>().isFlipped = true;
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().isFlipped = false;
        }
        
    }
}
