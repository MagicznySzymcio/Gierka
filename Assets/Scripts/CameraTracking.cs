using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -5);
    }
}