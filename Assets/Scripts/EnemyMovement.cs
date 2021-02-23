using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float maxVelocity = 8.0f;
    [SerializeField] private float velocityDelta = 50.0f;
    private float zeroVelocity = 0.0f;
    Rigidbody2D rb2d_en;

    void Start()
    {
        rb2d_en = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb2d_en.position.x > 5 && rb2d_en.velocity.x <= 0)
        {
            Debug.Log(rb2d_en.position.x);
            if (rb2d_en.velocity.x > -maxVelocity)
                rb2d_en.AddForce(new Vector2(-velocityDelta, zeroVelocity));

        }
        else if (rb2d_en.position.x < 10)
        {
            Debug.Log(rb2d_en.position.x);
            if (rb2d_en.velocity.x < maxVelocity)
                rb2d_en.AddForce(new Vector2(velocityDelta, zeroVelocity));
        }
    }
}

