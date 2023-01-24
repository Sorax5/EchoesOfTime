using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 10f;

    private float horizontalInput;
    
    private Rigidbody2D rb;
    private Collider2D coll;

    private bool greenBox, redBox;
    public float redXOffset, redYOffset, redXSize, redYSize, greenXOffset, greenYOffset, greenXSize, greenYSize;
    private float startingGrav;
    public LayerMask groundMask;

    private bool isGrabbing = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        startingGrav = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        greenBox = Physics2D.OverlapBox(new Vector2(transform.position.x + (greenXOffset * transform.localScale.x), transform.position.y + greenYOffset), new Vector2(greenXSize, greenYSize), 0f, groundMask);
        redBox = Physics2D.OverlapBox(new Vector2(transform.position.x + (redXOffset * transform.localScale.x), transform.position.y + redYOffset), new Vector2(redXSize, redYSize), 0f, groundMask);
        if (!isGrabbing)
        {
            this.horizontalInput = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            if (greenBox && !redBox && !isGrabbing && Input.GetButton("Jump"))
            {
                isGrabbing = true;
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.gravityScale = 0f;
            if (Input.GetButtonUp("Jump"))
            {
                ChangePos();
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }
    
    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, coll.bounds.extents.y + 0.1f);
    }

    public void ChangePos()
    {
        transform.position = new Vector2(transform.position.x + (0.5f * transform.localScale.x), transform.position.y + 3f);
        rb.gravityScale = startingGrav;
        isGrabbing = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + (redXOffset * transform.localScale.x), transform.position.y + redYOffset), new Vector2(redXSize, redYSize));
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + (greenXOffset * transform.localScale.x), transform.position.y + greenYOffset), new Vector2(greenXSize, greenYSize));
    }
}
