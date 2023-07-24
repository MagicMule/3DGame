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
        if (other.gameObject.CompareTag("NPC") && GameManager.Instance.InteractUIClosed)
        {
            //InteractUI.SetActive(true); // Open UI when colion with npc

            GameManager.Instance.talkNPCText.gameObject.SetActive(true);

            GameManager.Instance.InteractUIClosed = false; // UI is open -> set InteractUIClosed to false

        }
        else if (other.gameObject && !GameManager.Instance.InteractUIClosed)
        {
            //InteractUI.SetActive(false); // Close Ui when player activates InteractUI again (Must hit a gameObjekt)

            GameManager.Instance.talkNPCText.gameObject.SetActive(false);

            GameManager.Instance.InteractUIClosed = true; // UI is closed -> set interactUIClosed to True
        }


        // Player hit enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().HP = GameManager.Instance.DecreaseHP(other.gameObject.GetComponent<Enemy>().HP, 1); // hit enemy with 1 point of damage

            if (other.gameObject.GetComponent<Enemy>().HP <= 0) // Destory enemy
            {
                Destroy(other.gameObject);
            }

        }

        // Hit door objekt and the activet openCloseDoor, script on "doorHinge"
        if (other.gameObject.CompareTag("Door"))
        {
            other.gameObject.GetComponentInParent<OpenCloseDoor>().enabled = true;
        }

        if (other.gameObject.CompareTag("Lever"))
        {
            other.gameObject.GetComponentInParent<MoveLever>().enabled = true;
        }


    }

}

