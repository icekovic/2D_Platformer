using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private float speed;

    private Transform position;
    private float width;
    private bool isGrounded;

    void Start ()
    {
        position = transform;
        rigidBody = GetComponent<Rigidbody2D>();
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
	}

    void FixedUpdate()
    {
        //float horizontal = Input.GetAxis("Horizontal");

        //provjera ima li tla ispred
        Vector2 lineCastPosition = position.position - position.right * width;
        isGrounded = Physics2D.Linecast(lineCastPosition, lineCastPosition + Vector2.down, whatIsGround);

        //ako više nema tla, okreće se
        if(!isGrounded)
        {
            Vector3 currentRotation = position.eulerAngles;
            currentRotation.y += 180;
            position.eulerAngles = currentRotation;
        }

        Vector2 velocity = rigidBody.velocity;
        velocity.x = -position.right.x * speed;
        rigidBody.velocity = velocity;
    }

    void Update ()
    {
		
	}
}