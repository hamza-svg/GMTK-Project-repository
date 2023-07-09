using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float Rotatespeed = 5f;
   
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        Vector2 moveANDlook = new Vector2(movement.x, movement.y);
    

     if (movement.magnitude > 0)
     {
            float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90;
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Rotatespeed * Time.deltaTime);
     }

         // Move the character using the movement vector
         transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
