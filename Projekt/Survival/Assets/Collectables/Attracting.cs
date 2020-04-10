using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attracting : MonoBehaviour
{

    IMovement movement;
    Vector2 movementDirection;

    Transform player;


    [SerializeField]
    float attractingSpeed = 10f;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        movement = GetComponent<IMovement>();
    }

    private void Update()
    {
        ManageMovement();
    }

    void FixedUpdate()
    {
            movement.Move(movementDirection.normalized, attractingSpeed);

    }

    public void ManageMovement()
    {
        movementDirection = GetMovementDirection();
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 movementDirection = Vector3.zero;
        float springStrength;
        Vector3 dir;
        
        
            dir = -transform.position + player.transform.position;
            springStrength = 2f;
            movementDirection += dir * springStrength;
        
        return movementDirection;
    }
}
