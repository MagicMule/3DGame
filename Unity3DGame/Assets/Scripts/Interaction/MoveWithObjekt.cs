using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithObjekt : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            collision.gameObject.transform.parent = transform; // get colliding object transform to move realativ this objekts transform
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject)
        {
            collision.gameObject.transform.parent = null; // set exseting objekt to return to orignal transform parent
        }
    }

}
