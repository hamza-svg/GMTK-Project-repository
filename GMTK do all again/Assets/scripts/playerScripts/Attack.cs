using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Attacking")]
    public float attackRadius;
    public LayerMask layerMask;
    public Transform target;

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
    }

    private void OnDrawGizmos()
    {
        // Visualize the overlap circle in the Scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(target.position, attackRadius);
    }
}
