using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : HideMeshTrigger
{
    // Override the ActivateAndDeactivateObjekts method
    public override void ActivateAndDeactiveateObjekts(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerMeleeAttack") && PlayerInventory.Instance.key == true) // if the player has key, enable open door
        {
            foreach (GameObject aG in gameOvjektsToDeActivate)
            {
                if (aG != null)
                {
                    aG.SetActive(false);
                }
            }

            foreach (GameObject dG in gameOvjektsToActivate)
            {
                if (dG != null)
                {
                    dG.SetActive(true);
                }
            }

        }
    }
}
