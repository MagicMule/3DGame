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
            Debug.Log("Interating with" + other.gameObject.name);
            InteractUI.SetActive(true); // Open UI when colltion with npc
            InteractUiIsClosed = false;
        }
        else if (other.gameObject && !InteractUiIsClosed)
        {
            Debug.Log("Interakting with" + other.gameObject.name);
            InteractUI.SetActive(false); // Close Ui when player activates InteractUI agin (Must hit a gameObjekt)
            InteractUiIsClosed = true;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Interacting with" + other.gameObject.name);
            Debug.Log("HIT AND ENEMY!");
        }
    }
}

