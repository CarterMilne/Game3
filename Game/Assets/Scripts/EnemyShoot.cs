using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    GameObject BulletSnake;

    float fireRate;
    float nextFire;

    void Start ()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    void Update ()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(BulletSnake, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
