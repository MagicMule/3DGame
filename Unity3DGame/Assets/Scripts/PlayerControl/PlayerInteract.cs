using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    /// <summary>
    /// General interation, not tide to objekt or colidor
    /// </summary>

    
    //public KeyCode interactKey = KeyCode.E;

    //public KeyCode quitMenuKey = KeyCode.Escape;



    public GameObject popUpUI;
    private bool interatonHasHappend = false;

    public GameObject playerCameraMoveScript;
    private bool cameraActive = true;

    void Update()
    {
        Interact();
        QuitMenu();
        StopPlayerCameraMovment();
    }
    void Interact()
    {
        // when push E down, intreakt
        if (Input.GetKeyDown(InputManager.Instance.interactKeyNoColider) && !interatonHasHappend)
        {
            Debug.Log("Interact");

            interatonHasHappend = true;

        }

        // when E kay up, make new interaction ready
        if (Input.GetKeyUp(InputManager.Instance.interactKeyNoColider))
        {
            interatonHasHappend = false;
        }
    }

    void QuitMenu()
    {
        // exsit interationMenu
        if (Input.GetKeyDown(InputManager.Instance.quitMenuKey))
        {
            popUpUI.SetActive(false);
        }
    }

    //Start and stop player camera control
    void StopPlayerCameraMovment()
    {
        if (Input.GetKeyDown(InputManager.Instance.frezeCamera) && cameraActive)
        {
            Debug.Log("Stop player camera control");
            playerCameraMoveScript.GetComponent<PlayerCamera>().enabled = false;
            cameraActive = false;
        }
        else if (Input.GetKeyDown(InputManager.Instance.frezeCamera))
        {
            Debug.Log("Start player camera control");
            playerCameraMoveScript.GetComponent<PlayerCamera>().enabled = true;
            cameraActive = true;
        }
    }
}
