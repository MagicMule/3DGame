using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    /// <summary>
    /// General interation, not tide to objekt or colidor
    /// </summary>

 
    //public GameObject popUpUI;
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
        if (Input.GetKeyDown(GameManager.Instance.interactKeyNoColider) && !interatonHasHappend)
        {
            Debug.Log("Interact");

            interatonHasHappend = true;

        }

        // when E kay up, make new interaction ready
        if (Input.GetKeyUp(GameManager.Instance.interactKeyNoColider))
        {
            interatonHasHappend = false;
        }
    }

    void QuitMenu()
    {
        // exsit interationMenu
        if (Input.GetKeyDown(GameManager.Instance.quitMenuKey) && !GameManager.Instance.InteractUIClosed)
        {
            //popUpUI.SetActive(false);
            GameManager.Instance.talkNPCText.gameObject.SetActive(false);

            GameManager.Instance.InteractUIClosed = true;

        }
    }

    //Start and stop player camera control
    void StopPlayerCameraMovment()
    {
        if (Input.GetKeyDown(GameManager.Instance.frezeCamera) && cameraActive)
        {
            Debug.Log("Stop player camera control");
            playerCameraMoveScript.GetComponent<PlayerCamera>().enabled = false;
            cameraActive = false;
        }
        else if (Input.GetKeyDown(GameManager.Instance.frezeCamera))
        {
            Debug.Log("Start player camera control");
            playerCameraMoveScript.GetComponent<PlayerCamera>().enabled = true;
            cameraActive = true;
        }
    }
}
