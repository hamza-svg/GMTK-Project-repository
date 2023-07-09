using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool facingRight = true;
    public int maxHealth;

    public GameObject blood;
    public Animator anim;
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

        anim.SetFloat("MovementX", Mathf.Abs(movement.x));

        if (gameObject.GetComponent<Transform>().position.x >= 22.614 || gameObject.GetComponent<Transform>().position.x <= -19.61)
        {
            movement.x = 0;
        }

        if (gameObject.GetComponent<Transform>().position.y >= 9.616 || gameObject.GetComponent<Transform>().position.y <= -10.61)
        {
            movement.y = 0;
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
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Move on the End Screen
        Destroy(GameObject.Find("Player"));
    }
}
