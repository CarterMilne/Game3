using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float health = 250f;
    // the bosses health
   
    public void TakeDamage(float damage)
    {
        health -= damage;
        // takes damage if the players bullet touches 

        if (health <= 0)
        {
            Destroy(gameObject);
            // when the health is below zero then it will get destroyed 
        }
    }


   
} 
