using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHPManager : MonoBehaviour
{
    /// <summary>
    /// This holds the value for player HP and game over
    /// </summary>
    public static PlayerHPManager Instance;


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

    private void Update()
    {
        PlayerUIManager.Instance.playerHPText.text = $"HP: {playerHP}";
    }


    //Player game over event is to be put here
    public void PlayerGameOver()
    {
        GameManager.Instance.gameOver = true;

        Destroy(PlayerUIManager.Instance.playerHPText);

        PlayerUIManager.Instance.gameOverText.text = "GAME OVER";

        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
      

    }
}
