using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractCollider : MonoBehaviour
{
    /// <summary>
    /// This script is on the InteractCylinder gameobjekt
    /// The following are interactions that follow the gameobjekts colltion
    /// </summary>

    [Header("UI and general Objekt to cange by interaction")]
    public GameObject InteractUI;
    public bool InteractUIIsClosed = true;
    private void OnTriggerEnter(Collider other)
    {
        // Player interact with npc
        if (other.gameObject.CompareTag("NPC") && InteractUIIsClosed)
        {
            InteractUI.SetActive(true); // Open UI when colion with npc
            InteractUIIsClosed = false; // UI is open -> set InteractUIClosed to false
        }
        else if (other.gameObject && !InteractUIIsClosed)
        {
            InteractUI.SetActive(false); // Close Ui when player activates InteractUI again (Must hit a gameObjekt)
            InteractUIIsClosed = true; // UI is closed -> set interactUIClosed to True
        }

        // Player hit enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("HIT AND ENEMY!");
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Door"))
        {
            other.gameObject.GetComponentInParent<RotateDeg>().enabled = true;
            Debug.Log("Open Door");
        }


    }

}

