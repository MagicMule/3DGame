using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareTransform : MonoBehaviour
{
    /// <summary>
    /// The coliding objekt will share the same transform norm as this objekt
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            collision.gameObject.transform.parent = transform; // get colliding object transform to be the same as this objekts transform
        }
    }
}
