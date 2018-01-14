using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class testing : MonoBehaviour
{

    public float speed = 2f;

    private StateInput input;
    private Transform trans;
    private Rigidbody2D body;


    // Use this for initialization
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        input = GetComponent<StateInput>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(0, 0);
        if (input.leftButton)
            transform.Rotate(0, 0, 90);
        if (input.rightButton)
            transform.Rotate(0, 0, -90);
        if (transform.rotation.eulerAngles.z == 90)
        {

            if (input.forwardButton)
            {
                body.velocity = new Vector2(-speed, 0);
            }
            if (input.backwardButton)
            {
                body.velocity = new Vector2(speed, 0);
            }
        }
        if (transform.rotation.eulerAngles.z == 270)
        {

            if (input.forwardButton)
            {
                body.velocity = new Vector2(speed, 0);
            }
            if (input.backwardButton)
            {
                body.velocity = new Vector2(-speed, 0);
            }
        }
        if (transform.rotation.eulerAngles.z == 0)
        {

            if (input.forwardButton)
            {
                body.velocity = new Vector2(0, speed);
            }
            if (input.backwardButton)
            {
                body.velocity = new Vector2(0, -speed);
            }
        }
        if (transform.rotation.eulerAngles.z == 180)
        {
            if (input.forwardButton)
            {
                body.velocity = new Vector2(0, -speed);
            }
            if (input.backwardButton)
            {
                body.velocity = new Vector2(0, speed);
            }
        }
    }
}