using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    /// <summary>
    /// this is to prevent mulltiple overpaling walls
    /// check if walls with this script is colliding with another wall
    /// If it is, destory this gamebjekt, wall
    /// </summary>
    void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, .01f);

        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Wall")
            {
                Destroy(gameObject);
                return;
            }
        }
    }
}
