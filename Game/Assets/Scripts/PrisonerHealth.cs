using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonerHealth : MonoBehaviour
{
    public SceneData data;
    //the scene data object is variable named data
    public float health = 100;
    //this is the amount of enemys health

    void Start()
    {
        data = GameObject.Find("Data").GetComponent<SceneData>();
        // this calls the gameobject called data to help drop a medkit
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        // the snakes health minus the players damage

        if (health <= 0)
        {
            Instantiate(data.medkit, transform.position, Quaternion.identity);
            Destroy(gameObject);
            // this spawns the object at a spesifc point and rotation then destorys it 
        }
    }
}
