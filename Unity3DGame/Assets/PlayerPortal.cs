using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortal : MonoBehaviour
{
    // Player Portal Transopr
    // On coliton player i transported to pos of aplyed trasfomr objekt;
    public Transform portalExsitTransfrom;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = portalExsitTransfrom.transform.position;
        }
    }
}
