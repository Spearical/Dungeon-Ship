using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    private Rigidbody2D playerRb;
    private const float VERTICAL_BOUNDARY = 8.0f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        ConstrainPlayer();
    }

    void MovePlayer() 
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
        }
    }

    void ConstrainPlayer() 
    {
        if (transform.position.x > VERTICAL_BOUNDARY)
        {
            transform.position = new Vector2(VERTICAL_BOUNDARY, transform.position.y);
        }

        if (transform.position.x < -VERTICAL_BOUNDARY)
        {
            transform.position = new Vector2(-VERTICAL_BOUNDARY, transform.position.y);
        }
    }
}
