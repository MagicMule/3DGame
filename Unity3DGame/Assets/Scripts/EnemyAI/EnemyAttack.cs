using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    /// <summary>
    /// This scipt is to instaintat attack in player diraktion
    /// </summary>

    public Transform playerPos;


    private bool isAttackInRange = false;


    private MoveToPlayer moveToPlayerScript;
    private LookAtPlayer lookAtPlayerScript;

    [Header("GameObjekts used to initaite interaction")]
    public GameObject indecate; // Objekt that indecate incoming attack
    public GameObject attack; // attack Objekt that damge player



    [Header("Interaction")]
    public bool interactReady = true; // A bool to chek if a interaktin is ready
    public float interactDeley = 0.5f; // time befor next interaction bekoms avialable
    public float interactDuration = 0.2f; // active time of iteractor objekt

    private void Start()
    {
        moveToPlayerScript = GetComponentInParent<MoveToPlayer>();
        lookAtPlayerScript = GetComponentInParent<LookAtPlayer>();
    }



    private void Update()
    {

        isAttackInRange = moveToPlayerScript.isInStopPos; // Update the bool and chek if the enemy has stoped

        StartInteraction(); // Start Indecating attack

    }




    //Activate interacton
    void StartInteraction()
    {

        // If Enemy in range and interaction is ready, start to indekate that attack is comming
        if (interactReady && isAttackInRange)
        {
            lookAtPlayerScript.enabled = false; // Stop following player when making attack

            indecate.SetActive(true); // activet indecator objekt

            StartCoroutine(DoInteraction());
        }
    }

    //Set time the interactor colidor is to be active
    IEnumerator DoInteraction()
    {

        interactReady = false;

        yield return new WaitForSeconds(interactDuration);

        indecate.SetActive(false); // Stop indecator
        attack.SetActive(true); // Start attack
        attack.SetActive(true); // Start attack

        yield return new WaitForSeconds(interactDuration);

        attack.SetActive(false);

        lookAtPlayerScript.enabled = true; // enemy follow player again

        StartCoroutine(DelayInteraction()); // Start deley
    }

    // Set deley befor player can make another interaction
    IEnumerator DelayInteraction()
    {


        yield return new WaitForSeconds(interactDeley);

        
        
        interactReady = true;


    }


}
