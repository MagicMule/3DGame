using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ActivateInteraction : MonoBehaviour
{
    /// <summary>
    /// Here a gameobjekts, interactor, colider is used to initait an interaktion. 
    /// This script activates a objekt, making its colidor available for interaction with other gameobjekts.
    /// </summary>
    /// 


    [Header("GameObjekt used to initaite Player interaction")]
    public GameObject interactor;


    [Header("Player Interaction")]
    public bool interactReady = true; // A bool to chek if a interaktin is ready
    public float interactDeley = 0.5f; // time befor next interaction bekoms avialable
    public float interactDuration = 0.2f; // active time of iteractor objekt
    //public KeyCode interactKey = KeyCode.Mouse0;

    private void Update()
    {
        StartInteraction();
    }

    //Activate interactor
    void StartInteraction()
    {
        if (Input.GetKey(InputManager.Instance.interactKey) && interactReady)
        {
            interactor.SetActive(true);
            StartCoroutine(DoInteraction());
        }
    }

    //Set time the interactor colidor is to be active
    IEnumerator DoInteraction()
    {
        interactReady = false;

        yield return new WaitForSeconds(interactDuration);

        interactor.SetActive(false);

        StartCoroutine(DelayInteraction()); // Start deley
    }

    // Set deley befor player can make another interaction
    IEnumerator DelayInteraction()
    {
        yield return new WaitForSeconds(interactDeley);
        interactReady = true;
    }

}
