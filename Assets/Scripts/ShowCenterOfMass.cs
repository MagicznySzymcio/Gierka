using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCenterOfMass : MonoBehaviour
{
    public float Force;
    public GameObject DzidaObject;

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject Dzida = Instantiate(DzidaObject, transform.position, transform.rotation);
        Dzida.GetComponent<Rigidbody2D>().AddForce(transform.right * Force);
    }
}
