using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    public Transform cameraRotation;

    private void FixedUpdate()
    {
        // update the camera positon to applied objekts transform 
        transform.position = cameraPosition.position;
        transform.rotation = cameraRotation.localRotation;
    }
}
