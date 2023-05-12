using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGrund;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rB;

    private void Start()
    {
        rB = GetComponent<Rigidbody>();
        rB.freezeRotation = true; //physics will not alter body roation
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rB.drag = groundDrag;
        else
            rB.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }





    //Get input
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = ( orientation.forward * verticalInput ) + ( orientation.right * horizontalInput );

        rB.AddForce(10 * moveSpeed * moveDirection.normalized, ForceMode.Force);
    }

    // Manualy cotrol of speed
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rB.velocity.x, 0f, rB.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rB.velocity = new Vector3(limitedVel.x, rB.velocity.y, limitedVel.z); // limit velocity on x and z
        }
    }
}
