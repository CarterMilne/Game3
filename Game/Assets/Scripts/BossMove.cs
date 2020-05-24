using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{

    public float speed = 2.5f;
    Transform man;
    Rigidbody2D rb;
 
    void Start()
    {
        man = GameObject.FindGameObjectWithTag("Man").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Follow();
    }

    public void Follow()
    {
        Vector2 target = new Vector2(man.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }

}
