using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SceneData data;
    public float health = 100;
    //this is the amount of enemys health

    void Start()
    {
        data = GameObject.Find("Data").GetComponent<SceneData>();
    }

    public void TakeDamage (float damage)
    {
        health -= damage;
        // the snakes health minus the players damage
        
        if (health <= 0)
        {
            Instantiate(data.medkit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } 
    }
}
