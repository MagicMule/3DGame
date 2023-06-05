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

    float stopDistance = 1f ;

    private void Start()
    {
        savedMoveSpeed = enemyMoveSpeed;
    }
    void Update()
    {
        GetPlayerPos();
        MoveToPlayerPos();
        StopMove();
        Debug.Log("vectorToPlayer: " + vectorToPlayer);
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

        if( (Mathf.Abs(vectorToPlayer.x) < stopDistance || Mathf.Abs(vectorToPlayer.z) < stopDistance))
        {
            enemyMoveSpeed = 0;
        }
        else
        {
            enemyMoveSpeed = savedMoveSpeed;
        }

    }

}
