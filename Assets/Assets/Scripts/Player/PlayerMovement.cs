﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Stats")]
    public float playerSpeed;
    public float jumpForce;
    public int numberOfJumps;
    public int jumpsLeft;
    Rigidbody2D rb;
    float movement;

    [Header("GroundDetection")]
    bool drop;
    bool canDrop;
    bool isGrounded;
    public Transform groundDetection;
    public float detectionRadius;
    public LayerMask ground;
    public LayerMask platforms;

    Animator animator;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        jumpsLeft = numberOfJumps;

        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       Jump();
       Movement(); 
       DropDown();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(movement * playerSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundDetection.position, detectionRadius, ground);
        canDrop = Physics2D.OverlapCircle(groundDetection.position, detectionRadius, platforms);

        
    }
    

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            
            if (jumpsLeft > 0)
            {
                jumpsLeft--;
                rb.velocity = Vector2.up * jumpForce;
            }
            else if (jumpsLeft == 0 && isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        if (isGrounded)
        {
            
            jumpsLeft = numberOfJumps;
        }
        animator.SetBool("Jump", !isGrounded);
    }

    void Movement()
    {
        if (Input.GetButton("Horizontal"))
        {
            if (movement >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        

        animator.SetFloat("Movement", Mathf.Abs(movement));
    }

    void DropDown()
    {
        if (Input.GetButtonDown("Drop"))
        {
            drop = true;
        }
        else if(isGrounded && !canDrop)
        {
            drop = false;
        }
        if (drop && canDrop || !canDrop)
        {
           Physics2D.IgnoreLayerCollision(9,10,true); 
        }
        else
        {
            Physics2D.IgnoreLayerCollision(9,10,false); 
        }
        
    }

    private void OnDrawGizmos() {
        Gizmos.DrawSphere(groundDetection.position,detectionRadius);
    }
}
