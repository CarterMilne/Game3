﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    [SerializeField] public int speed = 4;
    // this serialize field allows the speed interger to be changed in the inspector
    private Rigidbody2D rb;
    // this is the rigidbody for the player
    private float inputHorizontal;
    // just is what moves the player along the axises
    public float maxHealth = 100f;
    // this is part of the players health system and the float is just set to the value of 100
    public float currentHealth;
    // this is the players current health is determinaed on the damage taken
    public PlayerHealth playerHealth;
    // calling the player health 
    public bool facingLeft = true;
    // the boolean is called facing left this at the start sets the charcters facingLeft variable to true
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // calling the rigidbody component on the character
        currentHealth = maxHealth;

        Canvas[] canvases = FindObjectsOfType<Canvas>();
        Canvas canvasMain = null;
        foreach(Canvas canvas in canvases)
        {
            if(canvas.gameObject.name == "CanvasHealthBar")
            {
                canvasMain = canvas;
                break;
            }
        }
        // this allows multiple canvases on the canvas helping for future game devolpment allowing the game to be more robust and flexable
        
        playerHealth = canvasMain.transform.Find("Health bar").GetComponent<PlayerHealth>();
        //playerHealth = transform.Find("Canvas").Find("PlayerHealth").GetComponent<PlayerHealth>();
        playerHealth.SetHealth(maxHealth);
        // the player health is the same as the set health in relation to the maximum health of the player
        facingLeft = true;
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        // when the a or d or the arrows are pressed the character will move x axis
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
        // the chacter is going to move at the speed variable set and the input that is chosen
        if (Input.GetButtonDown("Jump"))
            // when the w is pressed 
        {
            rb.velocity = new Vector2(rb.velocity.x, 8);
            // this will move the characters y axis by the set amount
        }
            Flip(inputHorizontal);
    }

    private void Flip(float inputHorizontal)
        // this is the flip function
    {
        if(inputHorizontal < 0 && !facingLeft || inputHorizontal > 0 && facingLeft )
            // when the input is a or d then the facing left will be flipped
        {
            facingLeft = !facingLeft;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            // flipping the scale from the inspector by -1 which flips the character

            transform.localScale = theScale;
        }
    }

    public void TakeDamage(float damage)
        // this function allows the character to take damage
    {
        currentHealth -= damage;
        // the players current health minus the damage from the enemy
        playerHealth.SetHealth(currentHealth);
        // the players health and current health in realtion

          if (currentHealth <= 0)
          {
            SceneManager.LoadScene("GameOver");
          } 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MedKit")
        {
            Destroy(col.gameObject);
            GainHealth(25f);
        }
    }

    public void GainHealth(float health)
    {
        currentHealth += health;
        playerHealth.SetHealth(currentHealth);
    }
}

