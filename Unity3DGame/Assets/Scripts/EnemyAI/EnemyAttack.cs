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
    }



    private void Update()
    {
        isAttackInRange = moveToPlayerScript.isInStopPos; // Update the bool and chek if the enemy has stoped



        StartInteraction(indecate); // Start Indecating attack

        StartInteraction(attack);



        transform.LookAt(playerPos); // Look at player, z point to playerPos 
    }





    //Activate interactor
    void StartInteraction(GameObject indecator)
    {
        if (interactReady && isAttackInRange)
        {
            indecator.SetActive(true);
            StartCoroutine(DoInteraction(indecator));
        }
    }

    //Set time the interactor colidor is to be active
    IEnumerator DoInteraction(GameObject indecator)
    {
        interactReady = false;

        yield return new WaitForSeconds(interactDuration);

        indecator.SetActive(false);

        StartCoroutine(DelayInteraction()); // Start deley
    }

    // Set deley befor player can make another interaction
    IEnumerator DelayInteraction()
    {
        yield return new WaitForSeconds(interactDeley);

        interactReady = true;
    }

}
