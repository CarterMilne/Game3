    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : MonoBehaviour
{
    public Transform firePoint;
    // this is the postion of the firepoint object in the game
    public GameObject bulletPrefab;
    // this is just calling the bullet 
    public SpriteRenderer player;
    // this is the player 
    
    void Start()
    {
        player = transform.GetComponent<SpriteRenderer>();
        // getting the players positon are orentaion from the sprite renderer
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            // this is when the left mouse button is pressed then it fires
        {
            Shoot();
            // this is what we called the shoot method to run
        }
    }

    void Shoot ()
    {
        if (player.flipX)
        {
           GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
           bullet.GetComponent<Bullet>().isFlipped = true;
            // this quaternion is used to roatate the bullet apon call when the bullet prefab is instantated which means it flips it when its called
            // when the bullet component is called then isFlipped variable is true
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().isFlipped = false;
            // same as before except it flips it the other way
        }
        
    }
}
