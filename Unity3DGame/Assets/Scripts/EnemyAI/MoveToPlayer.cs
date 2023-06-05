using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    /// <summary>
    /// This skript is atached to enemy
    /// It moves the atadched gameobjekt, playerPos - stopDistance
    /// The enemy would stop infromt of player
    /// </summary>


    public Transform playerPos;

    Vector3 vectorToPlayer;

    public float enemyMoveSpeed = 3f; 

    float savedMoveSpeed = 1f; // Saved movesped aplide StopMove, When enemy is to move

    public float distanceToPlayer;

    public bool isInStopPos = false; //This gb is in possition to stop

    public float stopDistance = 3f ;

    private void Start()
    {
        savedMoveSpeed = enemyMoveSpeed;

    }
    void Update()
    {
        GetDistanceToPlayer();
        GetPlayerPos();
        MoveToPlayerPos();
        StopMove();
        //Debug.Log( gameObject.name + " distance from " + playerPos.name + " is: " + distanceToPlayer);
    }
    void GetPlayerPos()
    {
        vectorToPlayer = new Vector3(playerPos.position.x - transform.position.x, 0f, playerPos.position.z - transform.position.z);
        
    }
     
    void MoveToPlayerPos()
    {
        vectorToPlayer.Normalize();
        transform.Translate(vectorToPlayer * Time.deltaTime * enemyMoveSpeed);
    }

    void StopMove()
    {
        GetPlayerPos();

        if( distanceToPlayer < stopDistance )
        {
            isInStopPos = true;
            enemyMoveSpeed = 0;
        }
        else
        {
            isInStopPos = false;
            enemyMoveSpeed = savedMoveSpeed;
        }

    }
    
    // Distance to playerPos and this gobjekt
    void GetDistanceToPlayer()
    {
        distanceToPlayer = Vector3.Distance(transform.position, playerPos.position);
    }



}
