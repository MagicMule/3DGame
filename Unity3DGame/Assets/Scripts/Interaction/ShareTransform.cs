using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareTransform : MonoBehaviour
{
    /// <summary>
    /// The coliding objekt will share the same transform norm as this objekt
    /// Usinge in elvetaros
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            Debug.Log(collision.gameObject + " is colliding");
            collision.gameObject.transform.parent = transform; // get colliding object transform to be the same as this objekts transform
        }
    }
}
