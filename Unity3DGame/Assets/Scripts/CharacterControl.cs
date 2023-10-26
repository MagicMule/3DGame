using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    /// <summary>
    /// Here a gameobjekts, interactor, colider is used to initait an interaktion. 
    /// This script activates a objekt, making its colidor available for interaction with other gameobjekts.
    /// </summary>
    /// 

    /// <summary>
    /// This script Shot out a loaded missile or efekt (on missileAttackPos)
    /// </summary>
    public static CharacterControl Instance;

    [Header("SPELL")]
    private bool missileAttackReady = false;
    public float missileAttackDeley = 0.5f;
    public GameObject[] missile;
    public GameObject missileAttackPos;
    public int spellSelected = 0;
    private Vector3 missileAttackPosOffset = new(0, 0, 0); //Positon
    private Vector3 missileAttackRotOffset = new(1, 1, 1); //Rotation
    public AudioClip missileAttackSound;

    [Header("GameObjekt USED TO INITAITE PLAYER INTERACTION")]
    public GameObject interactor;
    public GameObject spear;


    [Header("PLAYER INTERACTION")]
    public bool interactReady = true; // A bool to chek if a interaktin is ready
    public float interactDeley = 0.5f; // time befor next interaction bekoms avialable
    public float interactDuration = 0.2f; // active time of iteractor objekt
    private AudioSource interactAudioSource;
    public AudioClip interactAudioClip;
    public bool interactionModeAttack;
    public bool interactionModeInteract;

    [Header("MOVEMENT")]
    public float moveSpeed;
    public float groundDrag;
    public float airDrag;
    public Transform orientation; //Players curent oriantion, player should move forward when oriantaion is forward
    public float jumpForce = 5f;
    Vector3 moveDirection; // direction player is to move
    Vector3 playerMomentum;

    Rigidbody rB; // player rigeidbody

    public Vector3 customGravity = new Vector3(0f, 0f, 0f);

    /// <summary>
    /// General interation, not tide to objekt or colidor
    /// </summary>

    public GameObject cameraMoveScript;
    private bool cameraActive = true;

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

    private void Start()
    {
        Physics.gravity = Vector3.zero;
        rB = GetComponent<Rigidbody>();
        rB.freezeRotation = true; //physics will not alter body roation
    }

    private void Update()
    {
        interactAudioSource = GetComponent<AudioSource>();
        CangeSpell();
        ShotMissile();
        StartInteraction();
        GetGravityDirektion();
        StopPlayerCameraMovment();
        MyInput(); // Get imput from player
        SpeedControl(); // Contorl PlayerObj speed
        HandleDrag(); // Control playerObj drag
        if (Input.GetKeyDown(GameManager.Instance.jumpKey) && IsGrounded())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(); // Move PlayerObj based input
    }


    // Instansate Missile, att missle prefab postion
    void ShotMissile()
    {
        // Shot if typeout is done
        if (Input.GetKeyDown(GameManager.Instance.missileKey)  && DialogueManger.Instance.spellVerbal.GetComponent<TypeOutText>().typeOutDone)
        {
            MissileAttack();
            missileAttackReady = true;
        }

        //Shot spell when dialog is done
        if (spellSelected == 0 || spellSelected == 1 || spellSelected == 2)
        {
            if (DialogueManger.Instance.spellVerbal.GetComponent<TypeOutText>().typeOutDone && missileAttackReady)
            {
                Instantiate(missile[spellSelected], missileAttackPos.transform.position, missileAttackPos.transform.rotation);
                missileAttackReady = false;
            }
        }
        else
        {
            if (DialogueManger.Instance.spellVerbal.GetComponent<TypeOutText>().typeOutDone && missileAttackReady)
            {
                GameManager.Instance.playerHP += 1;
                missileAttackReady = false;
            }
        }
    }

    // missile instasiate at missileAttackPos
    void MissileAttack()
    {
        // cheek if last text rightout is done
        if (DialogueManger.Instance.spellVerbal.GetComponent<TypeOutText>().typeOutDone )
        {
            // Verbal conected to spells
            // Here alls alter text comp based on spell, color, text speed ev
            if (spellSelected == 0)
            {
                DialogueManger.Instance.spellVerbal.GetComponent<TextMeshProUGUI>().color = Color.cyan;
                DialogueManger.Instance.SpellVerbalDialog(0);

            }
            else if (spellSelected == 1)
            {
                DialogueManger.Instance.spellVerbal.GetComponent<TextMeshProUGUI>().color = Color.blue;
                DialogueManger.Instance.SpellVerbalDialog(1);

            }
            else if (spellSelected == 2)
            {
                // If there is no instance of Spell 3, do spell verb
                if (GameObject.FindGameObjectWithTag("Spell 3") == null)
                {
                    DialogueManger.Instance.spellVerbal.GetComponent<TextMeshProUGUI>().color = Color.white;
                    DialogueManger.Instance.SpellVerbalDialog(2);
                }
            }
            else if (spellSelected == 3)
            {
                DialogueManger.Instance.spellVerbal.GetComponent<TextMeshProUGUI>().color = Color.green;
                DialogueManger.Instance.SpellVerbalDialog(3);
            }
        }
    }

    public void CangeSpell()
    {
        if (Input.GetKeyDown(GameManager.Instance.hotKeyInput1))
        {
            spellSelected = 0;
            Debug.Log(missile[0].name + " selekted");
        }

        if (Input.GetKeyDown(GameManager.Instance.hotKeyInput2))
        {
            spellSelected = 1;
            Debug.Log(missile[1].name + " selekted");
        }

        if (Input.GetKeyDown(GameManager.Instance.hotKeyInput3))
        {
            spellSelected = 2;
            Debug.Log(missile[2].name + " selekted");
        }

        if (Input.GetKeyDown(GameManager.Instance.HotKeyInput4))
        {
            spellSelected = 3;
            Debug.Log("HealSpell");
        }

    }

    // Reset Missile pos and rotaion to that of missileattackPos gameobjekt
    public void ResetMissileAttackPos()
    {
        missileAttackPos.transform.position = new(0, 0, 3);
        missileAttackPos.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    public void CangeMissileOffset()
    {
        //Apply offset to range attack
        missileAttackPos.transform.position = missileAttackPos.transform.position + missileAttackPosOffset;
        missileAttackPos.transform.rotation = missileAttackPos.transform.rotation * Quaternion.Euler(missileAttackRotOffset); //Cange Deg
    }

    //Activate interactor
    // intercaton invlovs attack, talk to npc, open door and interact with objekt general
    void StartInteraction()
    {
        if (Input.GetKey(GameManager.Instance.meleeAttackKey) && interactReady)
        {
            interactionModeAttack = true;
            interactionModeInteract = false;

            interactAudioSource.PlayOneShot(interactAudioClip);
            spear.GetComponent<Animator>().SetTrigger("AttackTrigger");

            StartCoroutine(DoInteraction());

        }
        if (Input.GetKey(GameManager.Instance.interactKey) && interactReady)
        {
            interactionModeInteract = true;
            interactionModeAttack = false;

            StartCoroutine(DoInteraction());
        }
    }

    //Set time the interactor colidor is to be active
    IEnumerator DoInteraction()
    {
        interactor.SetActive(true);
        interactReady = false;

        yield return new WaitForSeconds(interactDuration);

        interactor.SetActive(false);

        StartCoroutine(DelayInteraction()); // Start deley
    }

    // Set deley befor player can make another interaction
    IEnumerator DelayInteraction()
    {
        yield return new WaitForSeconds(interactDeley);
        interactReady = true;
    }

    void GetGravityDirektion()
    {
        // Get the object's rotation
        Quaternion objectRotation = transform.rotation;
        // Calculate the gravity direction based on the object's rotation
        Vector3 gravityDirection = objectRotation * -Vector3.up;
        // Set the new gravity direction
        Physics.gravity = gravityDirection * customGravity.magnitude;
    }

    //Start and stop player camera control
    void StopPlayerCameraMovment()
    {
        if (Input.GetKeyDown(GameManager.Instance.frezeCamera) && cameraActive)
        {
            Debug.Log("Stop player camera control");
            cameraMoveScript.GetComponent<PlayerCamera>().enabled = false;
            cameraActive = false;
        }
        else if (Input.GetKeyDown(GameManager.Instance.frezeCamera))
        {
            Debug.Log("Start player camera control");
            cameraMoveScript.GetComponent<PlayerCamera>().enabled = true;
            cameraActive = true;
        }
    }


    private void HandleDrag()
    {
        if (IsGrounded())
        {
            rB.drag = groundDrag;
        }
        else
        {
            rB.drag = airDrag;
        }
    }

    //Get input
    private void MyInput()
    {
        GameManager.Instance.moveHorizontalInput = Input.GetAxisRaw("Horizontal");
        GameManager.Instance.MoveVerticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // calculate movement direction
        // player forwoard movement is were the charkater is looking
        moveDirection = (orientation.forward * GameManager.Instance.MoveVerticalInput) + (orientation.right * GameManager.Instance.moveHorizontalInput);
        //movement On ground
        if (IsGrounded()) // Player can only move on ground
        {
            //aply velocatry
            rB.AddForce(10 * moveSpeed * moveDirection.normalized, ForceMode.Force);
        }

        //movement in air
        if(!IsGrounded())
        {
            rB.AddForce(playerMomentum / 10, ForceMode.Force); // contiony movement speed momentum
        }
        playerMomentum = 10 * moveSpeed * moveDirection.normalized; //save player momentum
    }

    // Manualy cotrol of speed
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rB.velocity.x, 0f, rB.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed; // maxspeed will alwas be value "moveSpeed"
            rB.velocity = new Vector3(limitedVel.x, rB.velocity.y, limitedVel.z); // limit velocity on x and z
        }
    }

    private bool IsGrounded()
    {
        // Perform a raycast or collision check to determine if the player is grounded
        // Return true if grounded, false otherwise
        // Example: Use Raycast
        float raycastDistance = 0.8f;
        if (Physics.Raycast(transform.position, Vector3.down, out _, raycastDistance))
        {
            return true;
        }
        return false;
    }

    private void Jump()
    {
        rB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // add momentum up
    }
}
