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

    public Transform orientation; //Players curent oriantion, player should move forward when oriantaion forward


    Vector3 moveDirection; // direction player is to move

    Rigidbody rB; // player rigeidbody

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
    }

    private void HandleDrag()
    {
        rB.drag = groundDrag;
    }




    //Get input
    private void MyInput()
    {
        InputManager.Instance.moveHorizontalInput = Input.GetAxisRaw("Horizontal");
        InputManager.Instance.MoveVerticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // calculate movement direction
        // player forwoard movement is were the charkater is looking
        moveDirection = ( orientation.forward * InputManager.Instance.MoveVerticalInput) + ( orientation.right * InputManager.Instance.moveHorizontalInput);

        rB.AddForce(10 * moveSpeed * moveDirection.normalized, ForceMode.Force);

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
}
