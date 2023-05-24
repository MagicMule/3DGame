using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{/// <summary>
/// All player input values are stored here
/// </summary>
    public static InputManager Instance { get; private set; }


    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode JumpKey => jumpKey;


    public KeyCode interactKey = KeyCode.Mouse0;
    public KeyCode InteractKey => interactKey;


    public float moveHorizontalInput;
    public float MoveHorizontalInput
    {
        get => moveHorizontalInput;
        set { moveHorizontalInput = value; }
    }


    public float moveVerticalInput;
    public float MoveVerticalInput
    {
        get => moveVerticalInput;
        set { moveVerticalInput = value; }
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject  );
        }
    }
}
