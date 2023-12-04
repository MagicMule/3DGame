using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodHandOickup : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerInventory.Instance.godHand = true;
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("PlayerMeleeAttack"))
        {
            PlayerInventory.Instance.godHand = true;
            Destroy(gameObject);
        }
    }
}
