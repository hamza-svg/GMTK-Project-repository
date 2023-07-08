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
        gameObject.GetComponent<transformation>();
    }
    private void Update()
    {
        // Perform the overlap circle check
        Collider2D[] colliders = Physics2D.OverlapCircleAll(target.position, radius, layerMask);

        // Process the colliders that are within the overlap circle
        foreach (Collider2D collider in colliders)
        {
            // Do something with the collider (e.g., apply an effect, trigger an event)
            Debug.Log("Collided with: " + collider.gameObject.name);

            // Example: Check if the collided object has a specific tag
            if (collider.CompareTag("enemy"))
            {

                if (gameObject.GetComponent<transformation>().isWerewolf == true)
                {
                    Debug.Log("Hit an obstacle!");
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        Destroy(collider.gameObject);
                    }
                    collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
            else if (collider.CompareTag("enemy") == null)
            {
                collider.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

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
