using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    private void Update()
    {
        // update the camera pos to applied objekts transform
        transform.position = cameraPosition.position;
    }
}
