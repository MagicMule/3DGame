using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Inputs")]

    // Player camera rotaion disamle
    public KeyCode frezeCamera = KeyCode.F;
    public KeyCode FrezeCamera => frezeCamera;

    //

    public KeyCode interactKeyNoColider = KeyCode.E;
    public KeyCode InteractKeyNoColider => interactKeyNoColider;

    //

    public KeyCode quitMenuKey = KeyCode.Escape;
    public KeyCode QuitMenuKey => quitMenuKey;

    //

    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode JumpKey => jumpKey;

    //

    public KeyCode interactKey = KeyCode.Mouse0;
    public KeyCode InteractKey => interactKey;

    //

    public KeyCode missileKey = KeyCode.E;
    public KeyCode MissileKey => interactKey;

    //

    public float moveHorizontalInput;
    public float MoveHorizontalInput
    {
        get => moveHorizontalInput;
        set { moveHorizontalInput = value; }
    }

    //

    public float moveVerticalInput;
    public float MoveVerticalInput
    {
        get => moveVerticalInput;
        set { moveVerticalInput = value; }
    }

    //


    [Header("UI")]

    public TextMeshProUGUI playerHPText;

    public TextMeshProUGUI talkNPCText;

    public TextMeshProUGUI gameOverText;

    public TextMeshProUGUI messigeToPlayer;

    public TextMeshProUGUI playerDialog;

    public bool InteractUIClosed = true;

    [Header("Player HP")]

    public int playerHP = 10;

    public bool gameOver {  get; set; }


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

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        playerHPText.text = $"HP: {playerHP}";
    }


    // Call to deal damage
    public int DecreaseHP(int objektHP, int damgeTaken)
    {
        objektHP -= damgeTaken;
        return objektHP;
    }

    public int IncreseHP(int objektHP, int damgeRemoved)
    {
        objektHP += damgeRemoved;
        return objektHP;
    }


    //Set Gamer over text and load curent scene
    public void PlayerGameOver()
    {
        gameOver = true;

        Destroy(playerHPText);

        gameOverText.text = "GAME OVER";

        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }
}
