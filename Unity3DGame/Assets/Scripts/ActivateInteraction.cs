using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ActivateInteraction : MonoBehaviour
{
    [Header("GameObjekt used to initaite interaction")]
    public GameObject interactor;

    [Header("UI and general Objekt to cange by interaction")]
    public GameObject InteractUI;

    [Header("Interaction")]
    public bool interactReady = true;
    public float interactDeley = 0.5f; // time befor next interaction bekoms avialable
    public float interactDuration = 0.2f; // active time of iteractor objekt
    public KeyCode interactKey = KeyCode.Mouse0;

    private void Update()
    {
        StartInteraction();
    }

    void StartInteraction()
    {
        if (Input.GetKey(interactKey) && interactReady)
        {
            interactor.SetActive(true);
            StartCoroutine(DoInteraction());
        }
    }

    IEnumerator DoInteraction()
    {
        interactReady = false;

        yield return new WaitForSeconds(interactDuration);

        interactor.SetActive(false);

        StartCoroutine(DelayInteraction()); // Start deley
    }

    IEnumerator DelayInteraction()
    {
        yield return new WaitForSeconds(interactDeley);
        interactReady = true;
    }

}
