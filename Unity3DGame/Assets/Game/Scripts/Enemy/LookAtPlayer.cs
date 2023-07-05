using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform playerPos;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Transform>();
    }
    void Update()
    {
        transform.LookAt(playerPos);
    }
}