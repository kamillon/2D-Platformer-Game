using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private bool mustPatrol;
    public float walkSpeed;
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    private bool mustTurn;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;

    void Start()
    {
        mustPatrol = true;
    }

    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol || bodyCollider.IsTouchingLayers(groundLayer))
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
