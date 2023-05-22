using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode jumpKey = KeyCode.Space;

    public KeyCode interactKey = KeyCode.Mouse0;

    public float moveHorizontalInput;

    public float moveVerticalInput;

    public static InputManager Instance { get; private set; }

    public KeyCode JumpKey => jumpKey;

    public KeyCode InteractKey => interactKey;

    public float MoveHorizontalInput
    {
        get { return moveHorizontalInput; }
        set { moveHorizontalInput = value; }
    }

    public float MoveVerticalInput
    {
        get { return moveVerticalInput; }
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
