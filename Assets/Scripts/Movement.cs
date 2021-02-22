using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool doubleJump;
    public bool isGrounded;
    public LayerMask groundLayers;
    public float max_velocity = 8.0f;
    public float default_velocity = 3.0f;
    public float jump_velocity = 430.0f;
    private float zero_velocity = 0.0f;
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
                rb2d.AddForce(new Vector2(0, jump_velocity + rb2d.velocity.y));
            }
            else
            {
                if (doubleJump)
                {
                    rb2d.AddForce(new Vector2(0, jump_velocity + rb2d.velocity.y));
                    doubleJump = false;
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (rb2d.velocity.x < max_velocity)
                rb2d.AddForce(new Vector2(40.0f, zero_velocity));
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (rb2d.velocity.x > -max_velocity)
                rb2d.AddForce(new Vector2(-40.0f, zero_velocity));
        }
    }
}

