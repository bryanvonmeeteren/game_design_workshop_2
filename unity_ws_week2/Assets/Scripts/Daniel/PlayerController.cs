using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private Rigidbody rb;

    private float movementX;

    private float movementY;

    private float jumpDetectionLength;

    private RaycastHit hit;
    
    private bool isGrounded;

    [SerializeField] private float jumpStrength;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpDetectionLength = 1;
        jumpStrength = 300;
        speed = 10;
    }

    void OnMove(InputValue movementValue)
    {
        Debug.Log("attempting to move");
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 0f, 1f);
        Gizmos.DrawRay(transform.position, -transform.up * jumpDetectionLength);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        IsGrounded(jumpDetectionLength);
    }


    void OnJump()
    {
        Debug.Log("jump");
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpStrength);
            
        }
    }

    private void IsGrounded(float jumpDetectionLength)
    {
        Ray jumpRay = new Ray(transform.position, -Vector3.up);
        if (Physics.Raycast(jumpRay, out hit, jumpDetectionLength))
        {
            Debug.Log("ball is on ground");
            isGrounded = true;
            
        }
        else
        {
            
            Debug.Log("ball is in air");
            isGrounded = false;
        }
    }
}