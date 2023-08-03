using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MoveForward : MonoBehaviour
{
    // Simple move forward script, based on space self

    private Rigidbody rB;

    public int forwardSpeed = 1;


    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    // move objekt on the x axes 
    void Update()
    {
        transform.Translate(new Vector3(0, forwardSpeed) * Time.deltaTime, Space.Self);
    }
}
