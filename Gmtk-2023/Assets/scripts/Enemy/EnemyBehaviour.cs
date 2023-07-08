using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform player;
    public float maxHealth;
    [Range(0, 10)]
    public int sight;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool move;
    private float health;

    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector3 direction = player.position - transform.position;
        float distance = Vector3.Distance (player.position, transform.position);

        if (Mathf.Ceil(distance) <= sight)
        {
            move = false;
        } else {
            move = true;
        }
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        if (move)
        {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void GetHit(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(health);
        Destroy(gameObject);
    }
}
