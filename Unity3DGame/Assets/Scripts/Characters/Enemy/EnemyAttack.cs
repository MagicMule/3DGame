using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    /// <summary>
    /// This scipt is to instaintat attack in player diraktion
    /// Go to Player -> Stop -> Avtivate indecator in player diration -> activate attack in same diration -> 
    /// </summary>


    private bool isAttackInRange = false;

    private MoveToPlayer moveToPlayerScript;

    // Direktion enemy is to face
    private LookAtPlayer lookAtPlayerScript;

    // Direktion of enemy attack
    public LookAtPlayer direktionOfAttack;
    // If enemy is to have range attack
    public bool isRangedEnemy = false;

    [Header("GameObjekts used to initaite interaction")]
    public GameObject indecate; // Objekt that indecate incoming attack
    public GameObject attack; // attack Objekt that damge player
    public GameObject missileAttack;
    public GameObject enemyMissileAttackPos;


    [Header("Interaction")]
    public bool attackReady = true; // A bool to chek if a interaktin is ready
    public float attackDeley = 0.5f; // time befor next interaction bekoms avialable
    public float attackDuration = 0.2f; // active time of iteractor objekt

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
        if (attackReady && isAttackInRange)
        {
            direktionOfAttack.enabled = false; // Stop head to look att player
            lookAtPlayerScript.enabled = false; // Stop looking player when making attack
            moveToPlayerScript.enabled = false; // Stop follwing player when makaing attack

            indecate.SetActive(true); // activet indecator objekt

            StartCoroutine(DoInteraction());
        }
    }

    //Set time the interactor colidor is to be active
    IEnumerator DoInteraction()
    {

        attackReady = false;

        yield return new WaitForSeconds(attackDuration);

        indecate.SetActive(false); // Stop indecator
        attack.SetActive(true); // Start attack

        if (isRangedEnemy && missileAttack != null && enemyMissileAttackPos != null)
        {

            Instantiate(missileAttack, enemyMissileAttackPos.transform.position, enemyMissileAttackPos.transform.rotation); // shot missile
        }

        yield return new WaitForSeconds(attackDuration);

        attack.SetActive(false);

        direktionOfAttack.enabled = true;
        lookAtPlayerScript.enabled = true; // enemy look at player again
        moveToPlayerScript.enabled = true; // enemy follow player again

        StartCoroutine(DelayInteraction()); // Start deley
    }

    // Set deley befor player can make another interaction
    IEnumerator DelayInteraction()
    {


        yield return new WaitForSeconds(attackDeley);

        attackReady = true;


    }


}
