using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float acceleration = 10.0f;
    [SerializeField]
    private float airAcceleration = 5.0f;
    [SerializeField]
    private float jumpForce = 10.0f;
    
    private float horizontalInput;
    
    private Rigidbody2D rb;
    private Collider2D coll;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.horizontalInput = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        float acceleration = IsGrounded() ? this.acceleration : this.airAcceleration;
        
        rb.velocity = new Vector2(horizontalInput * acceleration, rb.velocity.y);
    }
    
    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, coll.bounds.extents.y + 0.1f);
    }
}
