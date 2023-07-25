using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    /// <summary>
    /// This skript is atached to enemy
    /// It moves the atadched gameobjekt, playerPos - stopDistance
    /// The enemy would stop infront of player
    /// </summary>

    [Header("Move to player")]

    private Transform playerPos;

    Vector3 vectorToPlayer;

    float savedMoveSpeed = 1f; // Saved movespeed

    private float speed = 1f;


    public float distanceToPlayer;

    public bool isInStopPos = false; //This gb is in possition to stop

    public float stopDistance = 3f;

    private float agroRange;

    private void Start()
    {
        playerPos = GetComponent<Enemy>().PlayerPos;

        agroRange = GetComponent<Enemy>().AgroRange;

        speed = GetComponent<Enemy>().Speed;

        savedMoveSpeed = speed;

    }
    void Update()
    {
        GetDistanceToPlayer();

        GetPlayerPos();

        if (distanceToPlayer <= agroRange) // move to player if in agro range
        {
            MoveToPlayerPos();
        }

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

    // Stop movement when player in range
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
            speed = savedMoveSpeed; // resume to move to player
        }

    }
    
    // Distance to playerPos and this gobjekt
    void GetDistanceToPlayer()
    {
        distanceToPlayer = Vector3.Distance(transform.position, playerPos.position);
    }



}
