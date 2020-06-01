using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touret : MonoBehaviour
{
    [SerializeField] GameObject BulletTouret;
    // this gameobject is the snakes shooting bullet prefab
    float fireRate;
    // the fire rate can be changed
    float nextFire;
    // the time for the next fire
    void Start()
    {
        fireRate = 1f;
        // the fire rate is one second
        nextFire = Time.time;
        // the next fire is equal to one Time.time
    }

    void Update()
    {
        CheckIfTimeToFire();
        // this just runs the fire function
    }

    void CheckIfTimeToFire()
    // the function for the enemy fire
    {
        if (Time.time > nextFire)
        {
            Instantiate(BulletTouret, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
            // the bullet is instantiatied which spawns it ehn is takes the fire rate and shoots
        }
    }
}
