using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    /// <summary>
    /// Activates trap
    /// </summary>

    public GameObject[] traps;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject)
        {
            foreach ( GameObject trap in traps)
            {
                trap.GetComponent<OpenCloseDoor>().enabled = true;
            }
        }
    }
}
