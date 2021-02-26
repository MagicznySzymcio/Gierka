using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasHit = false;
    private float rotate = 180;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (hasHit == false)
        {
            Rotate();
        }
    }

    void Rotate()
    {
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + rotate;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        int layerName = LayerMask.NameToLayer("groundLayers");
        if (collision.gameObject.layer == layerName) {
            hasHit = true;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            GetComponent<Collider2D>().enabled = false;
            rotate = rb.rotation;
            Rotate();
        }
    }
}
