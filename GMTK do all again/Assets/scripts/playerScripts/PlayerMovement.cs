using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool facingRight = true;
    public int maxHealth;

    public Rigidbody2D rb;

    Vector2 movement;
    int health;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Flip the player
        if (gameObject.name == "Player")
        {
            if (movement.x > 0 && !facingRight)
            {
                Flip();
            }
            
            if (movement.x < 0 && facingRight) {
                Flip();
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    public void GetHit(int damage)
    {
        health -= damage;
    }

    void Die()
    {
        // Move on the End Screen
        return;
    }
}
