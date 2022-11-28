using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol2 : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    private bool isFacingRigh;

    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (IsFacingRight())
        {
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }

    }

        private bool IsFacingRight()
        {
            return transform.localScale.x > Mathf.Epsilon;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
        }

}
