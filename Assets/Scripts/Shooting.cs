using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float Force;
    [SerializeField] private GameObject Bullet;
    private GameObject Player;
    public Transform DzidaContainer;

    void Start()
    {
        Player = gameObject;
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

        Vector3 mousePlacement = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mousePlacement);

        GameObject Dzida = Instantiate(Bullet, transform.position, transform.rotation, DzidaContainer);
        Dzida.GetComponent<Rigidbody2D>().AddForce(new Vector2(
                                                        castPoint.origin.x - Player.transform.position.x,
                                                        castPoint.origin.y - Player.transform.position.y) * Force);
        DzidaList.DzidaUpdate(Dzida);
    }
}
