using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDeg : MonoBehaviour
{
    public float rotationSpeed = 50f;  // Speed at which the object rotates
    public float targetDegrees = 90f; // Number of degrees to rotate

    private float currentRotation; // Current rotation in degrees

    private void Update()
    {
        OpenDoor();
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
            enabled = false; // Disable this script to stop further rotation
        }
    }
}