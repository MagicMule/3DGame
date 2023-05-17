using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;

    private bool interatonHasHappend = false;
    void Update()
    {
        Interact();
    }
    void Interact()
    {
        // when push E down, intreakt
        if (Input.GetKeyDown(interactKey) && !interatonHasHappend)
        {
            Debug.Log("Interact");

            interatonHasHappend = true;

        }

        // when E kay up, make new interaction ready
        if (Input.GetKeyUp(interactKey))
        {
            interatonHasHappend = false;
        }
    }
}
