using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerMeleeAttack"))
        {
            CharacterControl.Instance.playerHasSpel2 = true;
            PlayerInventory.Instance.spel2 = true;
            Destroy(gameObject);
        }
    }
}
