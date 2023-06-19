using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPManager : MonoBehaviour
{
    /// <summary>
    /// This holds the value for player HP and game over
    /// </summary>
    public static PlayerHPManager Instance;


    public bool gameOver = false;

    public int playerHP = 10;

    // The text were playerHP valus sould be desplayed in UI
    public TextMeshProUGUI playerHPText;

    // game over screan
    public TextMeshProUGUI gameOverText;
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

    private void Update()
    {
        PlayerUIManager.Instance.playerHPText.text = $"HP: {playerHP}";
    }

    public void PlayerDecreaseHP(int damgeToPlayer)
    {
        playerHP -= damgeToPlayer;
    }

    //Player game over event is to be put here
    public void PlayerGameOver()
    {
        gameOver = true;

        Destroy(playerHPText);

        gameOverText.text = "GAME OVER";
        
        Debug.Log("Game over");

    }
}
