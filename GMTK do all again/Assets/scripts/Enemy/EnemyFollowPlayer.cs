using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    // Public Variables
    public float speed;
    public float lineOfSight;
    public float shootingRange;
    public float fireRate = 1f;
    public GameObject bullet;
    public GameObject bulletParent;
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject blood;

    // Private Variables
    private float nextFireTime;
    private Transform Player;

    void Start()
    {
        currentHealth = maxHealth;
        Player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(Player.position, transform.position);
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        } else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time) {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }

    public void Hit(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

        Instantiate(blood);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
