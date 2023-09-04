using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    /// <summary>
    /// This gameobjekt is destroyed on colliton
    /// </summary>

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
