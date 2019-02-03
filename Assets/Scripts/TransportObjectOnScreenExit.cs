﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportObjectOnScreenExit : MonoBehaviour
{
    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    //float bottomConstraint = Screen.height;
    //float topConstraint = Screen.height;
    float buffer = 1.0f;
    Camera cam;
    //float distanceZ;

    void Start()
    {
        cam = Camera.main;
        //distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

        leftConstraint = cam.ScreenToWorldPoint(new Vector2(0.0f, 0.0f)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector2(Screen.width, 0.0f)).x;
        //bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        //topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;
    }

    void FixedUpdate()
    {
        if (transform.position.x < leftConstraint - buffer)
        {
            transform.position = new Vector2(rightConstraint + buffer, transform.position.y);
        }
        if (transform.position.x > rightConstraint + buffer)
        {
            transform.position = new Vector2(leftConstraint - buffer, transform.position.y);
        }
        //if (transform.position.y < bottomConstraint - buffer)
        //{
        //    transform.position = new Vector3(transform.position.x, topConstraint + buffer, transform.position.z);
        //}
        //if (transform.position.y > topConstraint + buffer)
        //{
        //    transform.position = new Vector3(transform.position.x, bottomConstraint - buffer, transform.position.z);
        //}
    }
}