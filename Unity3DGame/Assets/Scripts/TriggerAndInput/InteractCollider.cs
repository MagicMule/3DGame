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

    //public GameObject InteractUI;

    private void OnTriggerEnter(Collider other)
    {
        // Player interact with npc
        if (other.gameObject.CompareTag("NPC") && PlayerUIManager.Instance.InteractUIClosed)
        {
            //InteractUI.SetActive(true); // Open UI when colion with npc

            PlayerUIManager.Instance.talkNPCText.gameObject.SetActive(true);

            PlayerUIManager.Instance.InteractUIClosed = false; // UI is open -> set InteractUIClosed to false

        }
        else if (other.gameObject && !PlayerUIManager.Instance.InteractUIClosed)
        {
            //InteractUI.SetActive(false); // Close Ui when player activates InteractUI again (Must hit a gameObjekt)

            PlayerUIManager.Instance.talkNPCText.gameObject.SetActive(false);

            PlayerUIManager.Instance.InteractUIClosed = true; // UI is closed -> set interactUIClosed to True
        }

        // Player hit enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("HIT AND ENEMY!");

            Destroy(other.gameObject);
        }

        // Hit door objekt and the activet openCloseDoor, script on "doorHinge"
        if (other.gameObject.CompareTag("Door"))
        {
            other.gameObject.GetComponentInParent<OpenCloseDoor>().enabled = true;
        }


    }

}

