using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    private GameObject target;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }
}
