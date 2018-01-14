using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class move3D : MonoBehaviour
{

    public float speed = 2f;

    private StateInput input;
    private Transform trans;
    private Rigidbody body;


    // Use this for initialization
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        input = GetComponent<StateInput>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(0, body.velocity.y);
        if (input.leftButton)
            transform.Rotate(0, 90, 0);
        if (input.rightButton)
            transform.Rotate(0, -90, 0);
        if (transform.rotation.eulerAngles.y == 90)
        {

            if (input.forwardButton)
            {
                body.velocity = new Vector3(-speed, 0, 0);
            }
            if (input.backwardButton)
            {
                body.velocity = new Vector3(speed, 0, 0);
            }
        }
        if (transform.rotation.eulerAngles.y == 270)
        {

            if (input.forwardButton)
            {
                body.velocity = new Vector3(speed, 0, 0);
            }
            if (input.backwardButton)
            {
                body.velocity = new Vector3(-speed, 0, 0);
            }
        }
        if (transform.rotation.eulerAngles.y == 0)
        {

            if (input.forwardButton)
            {
                body.velocity = new Vector3(0, 0, speed);
            }
            if (input.backwardButton)
            {
                body.velocity = new Vector3(0, 0, -speed);
            }
        }
        if (transform.rotation.eulerAngles.y == 180)
        {

            if (input.forwardButton)
            {
                body.velocity = new Vector3(0, 0, -speed);
            }
            if (input.backwardButton)
            {
                body.velocity = new Vector3(0, 0, speed);
            }
        }
    }
}