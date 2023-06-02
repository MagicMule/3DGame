using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    private void FixedUpdate()
    {
        // update the camera positon to applied objekts transform 
        transform.position = new Vector3(cameraPosition.position.x, cameraPosition.position.y + 0.5f, cameraPosition.position.z);
    }
}
