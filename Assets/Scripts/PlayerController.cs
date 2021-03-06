﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // "Public" variables
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float groundCheckRadius = 0.15f;

    // Private variables
    private bool isGrounded = false;
    private Rigidbody2D rBody;
    private Animator anim;
    private bool isFacingRight = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Physics
    void FixedUpdate()
    {
       rBody.velocity = new Vector2(speed, rBody.velocity.y);

        isGrounded = GroundCheck();

        // Jumping code will go here!
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }



   
        // Check if sprite needs to be flipped
        if (isFacingRight && rBody.velocity.x < 0)
        {
            Flip();
        }
        else if (!isFacingRight && rBody.velocity.x > 0)
        {
            Flip();
        }

        anim.SetFloat("xSpeed", Mathf.Abs(rBody.velocity.x));
      
        anim.SetBool("isGrounded", isGrounded);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround); ;
    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }
}