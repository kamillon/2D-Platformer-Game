using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCo : MonoBehaviour
{
    public float speed = 10.0f;
    private float horizontalInput;
    private Rigidbody2D rb;
    private Animator anim;
    //private bool grounded;
    private BoxCollider2D boxCollider;
    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private float jumpForce = 8f;
    private Vector3 tempScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        //if (horizontalInput > 0.01f)
        //{
        //    transform.localScale = Vector3.one;
        //}
        //else if (horizontalInput < -0.01f)
        //{
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}


        horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;

        tempScale = transform.localScale;

        if (horizontalInput > 0)
            tempScale.x = Mathf.Abs(tempScale.x);
        else if (horizontalInput < 0)
            tempScale.x = -Mathf.Abs(tempScale.x);

        transform.localScale = tempScale;

        if (Input.GetKeyDown(KeyCode.Space) && checkGrounded())
            Jump();

        anim.SetBool("walk", horizontalInput != 0);
        anim.SetBool("grounded", checkGrounded());
    }

    private void Jump()
    {
        //rb.velocity = new Vector2(rb.velocity.x, speed);
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
        anim.SetTrigger("jump");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private bool checkGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

}
