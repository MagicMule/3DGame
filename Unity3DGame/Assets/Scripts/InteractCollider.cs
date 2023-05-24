using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractCollider : MonoBehaviour
{
    [Header("UI and general Objekt to cange by interaction")]
    public GameObject InteractUI;
    public bool InteractUiIsClosed = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC") && InteractUiIsClosed)
        {
            InteractUI.SetActive(true); // Open UI when colion with npc
            InteractUiIsClosed = false; // UI is open -> set InteractUiclosed to false
        }
        else if (other.gameObject && !InteractUiIsClosed)
        {
            InteractUI.SetActive(false); // Close Ui when player activates InteractUI agin (Must hit a gameObjekt)
            InteractUiIsClosed = true;
        }

        // Player hit enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("HIT AND ENEMY!");
        }
        Debug.Log("Interakting with " + other.gameObject.name);
    }
}

