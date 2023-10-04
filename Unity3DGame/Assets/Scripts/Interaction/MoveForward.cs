using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MoveForward : MonoBehaviour
{
    /// <summary>
    /// Simple move forward script, based on space self, used for missile movement and sutch
    /// </summary>

    public int forwardSpeed = 1;

    // move objekt on the x axes 
    void Update()
    {
        transform.Translate(new Vector3(0, forwardSpeed) * Time.deltaTime, Space.Self);
    }
}
