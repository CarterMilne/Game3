
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
    private bool facingLeft = true;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        playerHealth = canvasMain.transform.Find("Health bar").GetComponent<PlayerHealth>();
        //playerHealth = transform.Find("Canvas").Find("PlayerHealth").GetComponent<PlayerHealth>();
        playerHealth.SetHealth(maxHealth);
        facingLeft = true;
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 8);
        }

        Flip(inputHorizontal);
    }

    private void Flip(float inputHorizontal)
    {
        if(inputHorizontal < 0 && !facingLeft || inputHorizontal > 0 && facingLeft )
        {
            facingLeft = !facingLeft;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        playerHealth.SetHealth(currentHealth);

        /*  if (health <= 0)
          {
              Die();
          } */
    }
}

