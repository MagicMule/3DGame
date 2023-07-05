using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLever : MonoBehaviour
{
    /// <summary>
    /// simelar to OpenCloseDoor,
    /// The movement of a lever when puled
    /// </summary>
    /// 
    public float rotationSpeed = 50f;  // Speed at which the object rotates
    public float targetDegrees = 90f; // Number of degrees to rotate

    private float currentRotation; // Current rotation in degrees

    private bool leverIsPulled = true;

    public GameObject objektToMove;

    private void Update()
    {
        if (!leverIsPulled)
        {
            PullLeverForward();
        }
        else if (leverIsPulled)
        {
            PullLeverBack();
        }
    }

    void PullLeverForward()
    {

        // Rotate the object by rotationSpeed degrees per second
        // Rotates the y axses
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Update the current rotation, add the cange to current rotaton based on the roationspeed
        // Like above but only chek the value and not rotate
        currentRotation += rotationSpeed * Time.deltaTime;

        // Check if the current rotation has reached the target degrees
        if (currentRotation >= targetDegrees)
        {
            if (objektToMove.CompareTag("MoveSide"))
            {
                objektToMove.GetComponent<MoveToSide>().enabled = true; //move objekt with its MoveToSide script
            }

            if (objektToMove.CompareTag("Door"))
            {
                objektToMove.GetComponent<OpenCloseDoor>().enabled = true;
            }

            leverIsPulled = true; // The lever has reched the target

            currentRotation = 0; // reset current rotation calculation

            enabled = false; // Disable this script to stop further rotation
        }
    }

    void PullLeverBack()
    {

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * (-1)); // Rotate other direction

        currentRotation += rotationSpeed * Time.deltaTime;


        if (currentRotation >= targetDegrees)
        {
            if (objektToMove.CompareTag("MoveSide"))
            {
                objektToMove.GetComponent<MoveToSide>().enabled = true; //move objekt with its MoveToSide scriptw
            }

            if (objektToMove.CompareTag("Door"))
            {
                objektToMove.GetComponent<OpenCloseDoor>().enabled = true;
            }

            leverIsPulled = false;

            currentRotation = 0;

            enabled = false;
        }
    }
}
