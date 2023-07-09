using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Attacking")]
    public float attackRadius;
    public LayerMask layerMask;
    public Transform target;

    [Header("Dashing")]
    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown;

    private void Awake()
    {
        gameObject.GetComponent<Transformation>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(target.position, attackRadius, layerMask);
            Debug.Log(hitEnemies);
            foreach (Collider2D enemy in hitEnemies)
            {
                int damage = Random.Range(14, 20);
                enemy.GetComponent<EnemyFollowPlayer>().Hit(damage);
            }
        }

        if (Input.GetKeyDown(KeyCode.J) && canDash == true)
        {
            Dash();
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        Rigidbody2D rb = gameObject.GetComponent<PlayerMovement>().rb;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void OnDrawGizmos()
    {
        // Visualize the overlap circle in the Scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(target.position, attackRadius);
    }
}
