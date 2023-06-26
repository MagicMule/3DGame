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

    float savedMoveSpeed = 1f; // Saved movesped aplide StopMove, When enemy is to move

    public float speed = 1f;


    public float distanceToPlayer;

    public bool isInStopPos = false; //This gb is in possition to stop

    public float stopDistance = 3f;

    private void Start()
    {
        savedMoveSpeed = speed;

    }
    void Update()
    {
        GetDistanceToPlayer();
        GetPlayerPos();
        MoveToPlayerPos();
        StopMove();
    }
    void GetPlayerPos()
    {
        vectorToPlayer = new Vector3(playerPos.position.x - transform.position.x, 0f, playerPos.position.z - transform.position.z);
        
    }
     
    void MoveToPlayerPos()
    {
        vectorToPlayer.Normalize();
        transform.Translate(vectorToPlayer * Time.deltaTime * speed);
    }

    // Stop movement when player is close/ in range
    void StopMove()
    {
        GetPlayerPos();

        if( distanceToPlayer < stopDistance )
        {
            isInStopPos = true;
            speed = 0;
        }
        else
        {
            isInStopPos = false;
            speed = savedMoveSpeed;
        }

    }
    
    // Distance to playerPos and this gobjekt
    void GetDistanceToPlayer()
    {
        distanceToPlayer = Vector3.Distance(transform.position, playerPos.position);
    }



}
