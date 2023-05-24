using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    /// <summary>
    /// General interation, not tide to objekt or colidor
    /// </summary>
    
    
    public KeyCode interactKey = KeyCode.E;

    public KeyCode quitMenuKey = KeyCode.Escape;

    private bool interatonHasHappend = false;

    public GameObject popUpUI;

    void Update()
    {
        Interact();
        QuitMenu();
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

    void QuitMenu()
    {
        // exsit interationMenu
        if (Input.GetKeyDown(quitMenuKey))
        {
            popUpUI.SetActive(false);
        }
    }
}
