
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] public int speed = 4;
    private Rigidbody2D rb;
    private float inputHorizontal;

    public float maxHealth = 100f;
    public float currentHealth;
    public PlayerHealth playerHealth;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        playerHealth = transform.Find("Canvas").Find("PlayerHealth").GetComponent<PlayerHealth>();
        playerHealth.SetHealth(maxHealth);
        

    }


    void Update()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);

    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 8);

        }
    }

}

