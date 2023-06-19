using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{

    /// <summary>
    /// This is to handel all text and UI elements
    /// </summary>

    public static PlayerUIManager Instance;

    public TextMeshProUGUI playerHPText;

    public TextMeshProUGUI talkNPCText;

    public TextMeshProUGUI gameOverText;

    public TextMeshProUGUI messigeToPlayer;

    public TextMeshProUGUI playerDialog;

    public bool InteractUIClosed = true;


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
}
