using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float speed = 0f;
    public float maxSpeed = 5.0f;
    public float accel = 0.0f;
    public float maxAccel = 1.7f;
    public float radius = 1.0f;
    public float friction = 2f;

    void Update()
    {
        if (speed == 0.0f)
        {
            accel = 0.0f;
        }
    }
}