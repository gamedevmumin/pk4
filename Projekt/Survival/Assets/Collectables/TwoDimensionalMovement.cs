﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalMovement : MonoBehaviour, IMovement
{
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 input, float speed)
    {
        //AccelerateTo(input * speed, 5f);
        rb.velocity = input * speed * Time.deltaTime;

    }

}