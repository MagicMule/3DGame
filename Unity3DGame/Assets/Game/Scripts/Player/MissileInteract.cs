using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileInteract : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lever"))
        {
            other.gameObject.GetComponentInParent<MoveLever>().enabled = true;
            Destroy(gameObject);
        }
    }
}
