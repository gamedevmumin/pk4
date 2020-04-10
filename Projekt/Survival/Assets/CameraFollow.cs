using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    private Transform player;

    [SerializeField]
    float smoothSpeed = 0.125f;
    [SerializeField]
    float offset;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Vector3 playerpos = new Vector3(player.position.x + offset, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, playerpos, smoothSpeed);
    }
}