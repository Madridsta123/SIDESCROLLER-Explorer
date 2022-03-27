using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform groundPoint;
    [SerializeField] float waitingTime;
    [SerializeField] LayerMask groundLayer;
    Animator animator;
    Rigidbody2D rb;
    bool isGrounded;
    bool facingRight;
    bool canPatrol;
    bool isWaiting;
    int waitCounter;

    //Animator-Parameters
    const string animSpeed = "Speed";

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        canPatrol = true;
        isWaiting = false;
        waitCounter = 0;
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .3f, groundLayer);
        if (!isGrounded)
        {
            rb.velocity = Vector2.zero;
        }
        if (!isWaiting)
        {
            Movement();
        }
        else
        {
            WaitAtCorner();
        }
    }

    private void WaitAtCorner()
    {
        if (waitCounter == 0)
        {
            Invoke("Flip", waitingTime);
            waitCounter = 1;
        }
    }

    private void Movement()
    {
        animator.SetFloat(animSpeed, Mathf.Abs(rb.velocity.x));
        if (waitCounter == 1) waitCounter = 0;
        if (canPatrol)
        {
            if (isGrounded)
            {
                if (facingRight)
                {
                    rb.velocity = new Vector2(speed, 0);
                }
                else
                {
                    rb.velocity = new Vector2(-speed, 0);
                }
            }
            else
            {
                isWaiting = true;
            }
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        if (isWaiting)
        {
            isWaiting = false;
        }
    }
    public void SetCanPatrol(bool status)
    {
        canPatrol = status;
    }
    public bool GetFacingRight()
    {
        return facingRight;
    }
    public float GetSpeed()
    {
        return speed;
    }
}
