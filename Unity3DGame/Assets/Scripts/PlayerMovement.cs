using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    //[Header("Keybinds")]
    //public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight; // To chek distance from ground, for raycast
    public LayerMask whatIsGrund;
    bool grounded;

    public Transform orientation; //Players curent oriantion


    Vector3 moveDirection;

    Rigidbody rB;

    private void Start()
    {
        rB = GetComponent<Rigidbody>();
        rB.freezeRotation = true; //physics will not alter body roation
    }

    private void Update()
    {

        MyInput(); // Get imput from player

        SpeedControl(); // Contorl PlayerObj speed

        HandleDrag(); // Contraol playerObj drag

    }

    private void FixedUpdate()
    {
        MovePlayer(); // Move PlayerObj based input

        CheckIfGrounded(); // Check if playerObj i on ground
    }




    private void CheckIfGrounded()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight);
    }

    private void HandleDrag()
    {
        // handle drag
        if (grounded)
            rB.drag = groundDrag;
        else
            rB.drag = 0;
    }




    //Get input
    private void MyInput()
    {
        InputManager.Instance.moveHorizontalInput = Input.GetAxisRaw("Horizontal");
        InputManager.Instance.MoveVerticalInput = Input.GetAxisRaw("Vertical");

        //horizontalInput = Input.GetAxisRaw("Horizontal");
        //verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(InputManager.Instance.jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump(); // jump, apply force in y

            Invoke(nameof(ResetJump), jumpCooldown); //Invokes ResetJump after "jumCooldwon" sec
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = ( orientation.forward * InputManager.Instance.MoveVerticalInput) + ( orientation.right * InputManager.Instance.moveHorizontalInput);

        // in ground
        if(grounded)
            rB.AddForce(10 * moveSpeed * moveDirection.normalized, ForceMode.Force);

        // in air: cange total force apliade in move
        else if(!grounded)
            rB.AddForce(10 * airMultiplier * moveSpeed * moveDirection.normalized, ForceMode.Force);

    }

    // Manualy cotrol of speed
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rB.velocity.x, 0f, rB.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed; // maxspeed will alwas be value "moveSpeed"
            rB.velocity = new Vector3(limitedVel.x, rB.velocity.y, limitedVel.z); // limit velocity on x and z
        }
    }

    private void Jump()
    {
        // reset y velocity: This will make every jump the same hight
        rB.velocity = new Vector3(rB.velocity.x, 0, rB.velocity.z);

        rB.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
