using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    public Transform cameraRotation;

    private void Update()
    {
        // update the camera posto applied objekts transform 
        transform.position = cameraPosition.position;
        transform.rotation = cameraRotation.localRotation;
    }
}
