using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("INPUTS")]

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

    public KeyCode interactKey = KeyCode.E;
    public KeyCode InteractKey => interactKey;

    public KeyCode meleeAttackKey = KeyCode.Mouse0;
    public KeyCode MeleeAttackKey => interactKey;

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

    public KeyCode hotKeyInput1 = KeyCode.Alpha1;
    public KeyCode HotKeyInput1 => KeyCode.Alpha1;

    //

    public KeyCode hotKeyInput2 = KeyCode.Alpha2;
    public KeyCode HotKeyInput2 => KeyCode.Alpha2;

    //

    public KeyCode hotKeyInput3 = KeyCode.Alpha3;
    public KeyCode HotKeyInput3 => KeyCode.Alpha3;

    //


    public KeyCode hotKeyInput4 = KeyCode.Alpha4;
    public KeyCode HotKeyInput4 => KeyCode.Alpha4;

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

    public TextMeshProUGUI gameOverText;

    public GameObject spellUI1;
    public GameObject spellUI2;
    public GameObject spellUI3;
    public GameObject spellUI4;

    [Header("PLAYER")]

    public int playerHP = 10;

    public int meleeDamage = 1;

    public int spellDamage1 = 1;

    public bool spellReady = true;
    
    //List of relvent gameobjekts of a scene
    [Header("Interactive Objekts In Scene")]

    public List<GameObject> objekts;

    [Header("OBJEKT TRANSFROMATION")]

    public Transform PlayerTrans;
    public Transform MainCameraTrans;
    public Transform PlayerMissileAttackTrans;

    [Header("AUDIO")]

    public AudioClip generalHitEnemy;

    public bool gameOver { get; set; }


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
        PlayerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        MainCameraTrans = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        PlayerMissileAttackTrans = GameObject.FindGameObjectWithTag("PlayerSpellPos").GetComponent<Transform>();

        //Updaete player hp hud
        playerHPText.text = $"HP: {playerHP}";

        if (playerHP <= 0)
        {
            PlayerGameOver();
        }
    }



















    // Call to deal damage
    public int DecreaseHP(int objektHP, int damgeTaken)
    {
        Debug.Log("Gain HP");
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

    // Simple On/Off switch
    public void EfektOnAndOf(GameObject objetkToTurnOnOrOff, int onOrOff)
    {
        switch (onOrOff)
        {
            case 0: //On
                objetkToTurnOnOrOff.SetActive(true);
                break;

            case 1: //Off
                objetkToTurnOnOrOff.SetActive(false);
                break;



        }
    }


    /// <summary>
    /// To play aoudio at pos, cangeable pitch
    /// https://discussions.unity.com/t/adjust-properties-of-audiosource-created-with-playclipatpoint/51353
    ///*aldonaletto
    /// <summary>
    public AudioSource PlayClipAt(AudioClip clip, float clipVolume, float clipPitch, Vector3 pos)
    {
        GameObject tempGO = new ("TempAudio"); // create the temp object
        tempGO.transform.position = pos; // set its position

        AudioSource aSource = tempGO.AddComponent(typeof(AudioSource)) as AudioSource; // add an audio source
        
        aSource.clip = clip; // define the clip
        aSource.pitch = clipPitch; // set pitch
        aSource.volume = clipVolume; // set voldume

        // set other aSource properties here, if desired
        aSource.Play(); // start the sound
        Destroy(tempGO, clip.length); // destroy object after clip duration
        return aSource; // return the AudioSource reference
    }
}