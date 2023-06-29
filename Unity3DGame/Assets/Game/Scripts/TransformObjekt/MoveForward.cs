using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Simple move forward script, based on space self

    private Rigidbody2D rB;

    public int forwardSpeed = 1;


    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    // move objekt on the x axes 
    void Update()
    {
        transform.Translate(new Vector2(0, forwardSpeed) * Time.deltaTime, Space.Self);
    }
}
