using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjekt : MonoBehaviour
{
    //Destroy objekts with Destructanle tag

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destructable"))
        {
            Destroy(other.gameObject);
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destructable"))
        {
            Destroy(collision.gameObject);
        }
        
    }
    */
}
