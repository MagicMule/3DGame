using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    public static PlayerHPManager Instance;

    public bool gameOver = false;

    public int playerHP = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDecreaseHP(int damgeToPlayer)
    {
        playerHP -= damgeToPlayer;
    }

    public void PlayerGameOver()
    {
        gameOver = true;
        Debug.Log("Game over");
    }
}
