using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileInteract : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        // Pull lever by missile
        {
            Debug.Log("Hit with spell");
            other.gameObject.GetComponentInParent<MoveLever>().enabled = true;
        }

    }
}
