using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

        yRotation += mouseX;
        xRotation -= mouseY;

        //the objket cant look up or down more then 90deg 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ( |xRotation| < 90 )

        // rotate camera and oriantaion
        transform.rotation = Quaternion.Euler(xRotation, yRotation, orientation.rotation.z); // camera X and Y rotation
        orientation.rotation = Quaternion.Euler(orientation.rotation.x, yRotation, orientation.rotation.z); // objekt Y rotation 
    }

}
