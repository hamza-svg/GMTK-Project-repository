using UnityEngine;

public class attack : MonoBehaviour
{
    public float radius = 5f;
    public LayerMask enemyLayer;
    public float jumpForce = 10f;

    public GameObject target;

    private void Update()
    {
        if (gameObject.GetComponent<Transformation>().isWareWolf)
        { // Check if the space key is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Perform the overlap circle check
                Collider2D[] colliders = Physics2D.OverlapCircleAll(target.transform.position, radius, enemyLayer);

                if (colliders.Length > 0)
                {
                    // Find the closest enemy
                    Collider2D closestEnemy = colliders[0];
                    float closestDistance = Vector2.Distance(transform.position, closestEnemy.transform.position);

                    foreach (Collider2D collider in colliders)
                    {
                        float distance = Vector2.Distance(transform.position, collider.transform.position);
                        if (distance < closestDistance)
                        {
                            closestEnemy = collider;
                            closestDistance = distance;
                        }
                    }

                    // Jump towards the closest enemy
                    Vector2 jumpDirection = closestEnemy.transform.position - transform.position;
                    GetComponent<Rigidbody2D>().AddForce(jumpDirection.normalized * jumpForce, ForceMode2D.Impulse);
                    
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Visualize the overlap circle in the Scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(target.transform.position, radius);
    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<Transformation>().isWareWolf)
        {
            if (collision.collider.tag == "enemy")
            {
                Destroy(collision.gameObject);
            }
        }
        
    }*/
}
