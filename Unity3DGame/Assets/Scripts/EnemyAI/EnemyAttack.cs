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

    float stopDistance;

    private MoveToPlayer moveToPlayerScript;

    [Header("GameObjekt used to initaite interaction")]
    public GameObject interactor;



    [Header("Interaction")]
    public bool interactReady = true; // A bool to chek if a interaktin is ready
    public float interactDeley = 0.5f; // time befor next interaction bekoms avialable
    public float interactDuration = 0.2f; // active time of iteractor objekt

    private void Start()
    {
        moveToPlayerScript = GetComponentInParent<MoveToPlayer>();
    }

    private void Update()
    {
        isAttackInRange = moveToPlayerScript.isInStopPos; // Update the bool and chek if the enemy has stoped
        StartInteraction();
        transform.LookAt(playerPos); // Look at player, z point to playerPos 
    }

    //Activate interactor
    void StartInteraction()
    {
        if (interactReady && isAttackInRange)
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

    // If player is coles enotu the attack happen
    
    /*
    void ChekIfPlayerIsInRange()
    {
        if( Vector3.Distance(transform.position, playerPos.position) > stopDistance)
        {
            isAttackInRange = true;
        }
        else
        {
            isAttackInRange = false;
        }
    }
    */

}
