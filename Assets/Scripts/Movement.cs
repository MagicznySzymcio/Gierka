using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float maxVelocity = 8.0f;
    [SerializeField] private float velocityDelta = 50.0f;
    [SerializeField] private float jumpVelocity = 9.0f;
    private float zeroVelocity = 0.0f;
    private bool doubleJump;
    private bool isGrounded;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 1.0f),
            new Vector2(transform.position.x + 0.5f, transform.position.y - 1.05f), groundLayers);

        if (isGrounded)
        {
            doubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                rb2d.velocity += Vector2.up * jumpVelocity;
            }
            else
            {
                if (doubleJump)
                {
                    rb2d.velocity += Vector2.up * (jumpVelocity + Math.Abs(rb2d.velocity.y));
                    doubleJump = false;
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (rb2d.velocity.x < maxVelocity)
                rb2d.AddForce(new Vector2(velocityDelta, zeroVelocity));
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (rb2d.velocity.x > -maxVelocity)
                rb2d.AddForce(new Vector2(-velocityDelta, zeroVelocity));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "End")
        {
            collision.GetComponent<EndGame>().OnGameEnd();
        }
    }
}

