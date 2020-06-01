using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [SerializeField] GameObject BossBullet;
    // the bosses gameobject is called
    float fireRate;
    // the set fire rate
    float nextFire;
  
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    // the function for the enemy fire
    {
        if (Time.time > nextFire)
        {
            Instantiate(BossBullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
            // the bullet is instantiatied which spawns it ehn is takes the fire rate and shoots
        }
    }
}
