using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    private Transform aimTransform;
    private Vector3 pos, scale;
    private bool canShoot = true;
    private GameObject Barrel;
    [SerializeField] private float fireRateTime = 0.1f;
    void Start()
    {
        aimTransform = transform.Find("AK-47");
        pos = aimTransform.position;
        scale = aimTransform.localScale;
        Barrel = aimTransform.gameObject.transform.Find("Barrel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        if(Input.GetMouseButton(0))
        {
            if (canShoot)
            {
                StartCoroutine(fireRate());
            }
        }
    }

    IEnumerator fireRate()
    {
        Shoot();
        canShoot = false;
        yield return new WaitForSeconds(fireRateTime);
        canShoot = true;
    }

    void Aim()
    {
        Vector3 mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        Vector3 object_pos = Camera.main.WorldToScreenPoint(aimTransform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        if (angle < 90 && angle >= -90)
        {
            if (aimTransform.localScale.y < 0)
            {
                scale.y *= -1;
                aimTransform.localScale = scale;
                pos.x = gameObject.transform.position.x + 0.2f;
                pos.y = gameObject.transform.position.y - 0.3f;
                aimTransform.position = pos;
            }
        }
        else
        {
            if (aimTransform.localScale.y > 0)
            {
                scale.y *= -1;
                aimTransform.localScale = scale;
                pos.x = gameObject.transform.position.x - 0.2f;
                pos.y = gameObject.transform.position.y - 0.3f;
                aimTransform.position = pos;
            }
        }
        aimTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    void Shoot()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;

        GameObject bullet = Instantiate(Bullet, Barrel.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * 50;
    }
}
