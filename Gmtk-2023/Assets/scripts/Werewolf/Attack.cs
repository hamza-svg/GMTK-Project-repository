using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float radius = 1f;
    public LayerMask layerMask;
    public Transform target;

    private void Awake()
    {
        gameObject.GetComponent<Transformation>();
    }
    private void Update()
    {
        // Check if space is pressed
        bool isKeyDown = Input.GetKey(KeyCode.Space);

        // Perform the overlap circle check
        Collider2D[] colliders = Physics2D.OverlapCircleAll(target.position, radius, layerMask);

        // Process the colliders that are within the overlap circle
        foreach (Collider2D collider in colliders)
        {
            // Do something with the collider (e.g., apply an effect, trigger an event)
            Debug.Log("Collided with: " + collider.gameObject.name);

            // Example: Check if the collided object has a specific tag
            if (collider.CompareTag("Enemy"))
            {                

                if (gameObject.GetComponent<Transformation>().isWerewolf == true)
                {
                    Debug.Log("Hit an obstacle!");
                    
                    if (isKeyDown)
                    {
                        Destroy(collider.gameObject);
                    }
                    collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
            else if(collider.CompareTag("Enemy") == null)
            {
                collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;

            }
        }
    }

    private void OnDrawGizmos()
    {
        // Visualize the overlap circle in the Scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(target.position, radius);
    }
}
