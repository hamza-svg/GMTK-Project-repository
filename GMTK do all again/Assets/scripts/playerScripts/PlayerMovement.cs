using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // Rotate the character towards the movement direction
        if (movement.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90;
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
            rb.MoveRotation(Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
        }

        // Apply movement to the rigidbody
        rb.velocity = movement * moveSpeed;
    }
}
