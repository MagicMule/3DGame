using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
    /// <summary>
    /// This Open or closeds door
    /// AORN objekts alterde by this svripts funtons porly as player platform
    /// </summary>

    public float rotationSpeed = 50f;  // Speed at which the object rotates
    public float targetDegrees = 90f; // Number of degrees to rotate

    private float currentRotation; // Current rotation in degrees

    private bool doorIsClosed = true;

    private void Update()
    {
        if (doorIsClosed)
        {
            OpenDoor();
        }
        else if (!doorIsClosed)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {

        // Rotate the object by rotationSpeed degrees per second
        // Rotates the y axses
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Update the current rotation, add the cange to current rotaton based on the roationspeed
        // Like above but only chek the value and not rotate
        currentRotation += rotationSpeed * Time.deltaTime;

        // Check if the current rotation has reached the target degrees
        if (currentRotation >= targetDegrees)
        {
            doorIsClosed = false; // The door has reched the target


            currentRotation = 0; // reset current rotation calculation

            enabled = false; // Disable this script to stop further rotation
        }
    }

    void CloseDoor()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * (-1)); // Rotate other direction

        currentRotation += rotationSpeed * Time.deltaTime;

        if (currentRotation >= targetDegrees)
        {
            doorIsClosed = true;

            currentRotation = 0;

            enabled = false;
        }
    }
}
