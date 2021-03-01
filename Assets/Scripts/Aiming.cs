using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Transform aimTransform;
    void Start()
    {
        aimTransform = transform.Find("TestGun");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePlacement = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mousePlacement);
        
        float angle = Mathf.Atan2(castPoint.origin.y, castPoint.origin.x) * Mathf.Rad2Deg;
        aimTransform.rotation = Quaternion.Euler(0,0,angle);
    }
}
