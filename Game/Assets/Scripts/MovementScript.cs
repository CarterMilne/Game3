    
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
    public bool canJump = true;
    // the boolean is called facing left this at the start sets the charcters facingLeft variable to true
    public bool displayText;
    /*
    float raycastLength = 5f;
    public Transform groundCheckOne;
    public Transform groundCheckTwo;
    public Transform groundCheckThree;
    */
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // calling the rigidbody component on the character
        currentHealth = maxHealth;

        Canvas[] canvases = FindObjectsOfType<Canvas>();
        Canvas canvasMain = null;
        foreach (Canvas canvas in canvases)
        {
            if (canvas.gameObject.name == "CanvasHealthBar")
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
        
        /*
        groundCheckOne = GameObject.Find("groundCheckOne").transform;
        groundCheckTwo = GameObject.Find("groundCheckTwo").transform;
        groundCheckThree = GameObject.Find("groundCheckThree").transform;
        */

    }

    void Update()
    { 
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        // when the a or d or the arrows are pressed the character will move x axis
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
        // the chacter is going to move at the speed variable set and the input that is chosen
        if (Input.GetButtonDown("Jump") /*&& canJump*/)
        // when the w is pressed 
        {
            rb.velocity = new Vector2(rb.velocity.x, 8);
            // this will move the characters y axis by the set amount
            
        }
     /*   if (PlayerIsGrounded())
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        */
        Flip(inputHorizontal);
    }

    private void Flip(float inputHorizontal)
    // this is the flip function
    {
        if (inputHorizontal < 0 && !facingLeft || inputHorizontal > 0 && facingLeft)
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
        if (col.gameObject.tag == "Touret")
        {
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Void")
        {
            SceneManager.LoadScene("GameOver");
        }
        if (col.gameObject.tag == "NPC")
        {
           bool displayText = true;
        }
        if (col.gameObject.tag == "MenuDoor")
        {
            SceneManager.LoadScene("Menu and Intro");
        }
        if (col.gameObject.tag == "RestartDoor")
        {
            SceneManager.LoadScene("Level 1");
        }
        if (col.gameObject.tag == "PrisonDoor")
        {
            SceneManager.LoadScene("End Level");
        }
    }

    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Door")
        {
            SceneManager.LoadScene("Level 2");
        }
    }

    public void GainHealth(float health)
    {
        currentHealth += health;
        playerHealth.SetHealth(currentHealth);
    }
    /*
    public bool PlayerIsGrounded()
    {
        
        bool groundCheck1 = Physics2D.Raycast(groundCheckOne.localPosition, -Vector2.down, raycastLength, LayerMask.GetMask("Ground"));
        bool groundCheck2 = Physics2D.Raycast(groundCheckTwo.localPosition, -Vector2.down, raycastLength, LayerMask.GetMask("Ground"));
        bool groundCheck3 = Physics2D.Raycast(groundCheckThree.localPosition, -Vector2.down, raycastLength, LayerMask.GetMask("Ground"));
        
        if (groundCheck1 || groundCheck2 || groundCheck3)
        {
        return true;
        }
        return false;
    }
    */
}

