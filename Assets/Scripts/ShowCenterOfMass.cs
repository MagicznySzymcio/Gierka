using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCenterOfMass : MonoBehaviour
{
    public float currForce;
    public float Force;
    public GameObject DzidaObject;
    public GameObject Player;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot()
    {

        Vector3 mousePlacement = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mousePlacement);

        GameObject Dzida = Instantiate(DzidaObject, transform.position, transform.rotation);
        Dzida.GetComponent<Rigidbody2D>().AddForce(new Vector2(
                                                        castPoint.origin.x - Player.transform.position.x,
                                                        castPoint.origin.y - Player.transform.position.y) * Force);
    }
}
