using System.Collections;
using System.Collections.Generic;
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


    [Header("SPELL")]
    public bool missileAttackReady = true;
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
    //public KeyCode interactKey = KeyCode.Mouse0;
    private AudioSource interactAudioSource;
    public AudioClip interactAudioClip;

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

    //public GameObject popUpUI;
    private bool interatonHasHappend = false;

    public GameObject cameraMoveScript;
    private bool cameraActive = true;

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

        Interact();

        QuitMenu();

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

        if (Input.GetKeyDown(GameManager.Instance.missileKey) && missileAttackReady)
        {

            StartCoroutine(MissileAttack());
        }
    }

    // missile instasiate at missileAttackPos
    IEnumerator MissileAttack()
    {

        missileAttackReady = false;

        Instantiate(missile[spellSelected], missileAttackPos.transform.position, missileAttackPos.transform.rotation);


        yield return new WaitForSeconds(missileAttackDeley); // Time befor player can make onather missile attack

        missileAttackReady = true;
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
    void StartInteraction()
    {
        if (Input.GetKey(GameManager.Instance.interactKey) && interactReady)
        {
            interactAudioSource.PlayOneShot(interactAudioClip);

            spear.GetComponent<Animator>().SetTrigger("AttackTrigger");

            interactor.SetActive(true);
            StartCoroutine(DoInteraction());
        }
    }

    //Set time the interactor colidor is to be active
    IEnumerator DoInteraction()
    {
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


    void Interact()
    {
        // when push E down, intreakt
        if (Input.GetKeyDown(GameManager.Instance.interactKeyNoColider) && !interatonHasHappend)
        {
            Debug.Log("Interact");

            interatonHasHappend = true;

        }

        // when E kay up, make new interaction ready
        if (Input.GetKeyUp(GameManager.Instance.interactKeyNoColider))
        {
            interatonHasHappend = false;
        }
    }

    void QuitMenu()
    {
        // exsit interationMenu
        if (Input.GetKeyDown(GameManager.Instance.quitMenuKey) && !GameManager.Instance.InteractUIClosed)
        {
            //popUpUI.SetActive(false);
            GameManager.Instance.messigeToPlayer.gameObject.SetActive(false);

            GameManager.Instance.InteractUIClosed = true;

        }
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


        if (IsGrounded()) // Player can only move on ground
        {
            //aply velocatry
            rB.AddForce(10 * moveSpeed * moveDirection.normalized, ForceMode.Force);
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
        float raycastDistance = 0.6f;
        if (Physics.Raycast(transform.position, Vector3.down, out _, raycastDistance))
        {
            return true;
        }
        return false;
    }

    private void Jump()
    {
        rB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // add momentum up
        rB.AddForce(playerMomentum, ForceMode.Impulse); // contiony movement speed momentum
    }
}
