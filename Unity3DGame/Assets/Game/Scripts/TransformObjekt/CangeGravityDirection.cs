using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CangeGravityDirection : MonoBehaviour
{
    public Vector3 customGravity = new Vector3(0f, 0f, 0f);

    private void Start()
    {
        Physics.gravity = Vector3.zero;
    }

    private void Update()
    {
        // Get the object's rotation
        Quaternion objectRotation = transform.rotation;

        // Calculate the gravity direction based on the object's rotation
        Vector3 gravityDirection = objectRotation * -Vector3.up;

        // Set the new gravity direction
        Physics.gravity = gravityDirection * customGravity.magnitude;
    }

    void GetGravityDirektion()
    {
        
    }
}
