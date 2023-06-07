using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform playerPos;
    void Update()
    {
        transform.LookAt(playerPos);
    }
}
