using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public KeyCode jumpKey { get; private set; }

    public KeyCode interactKey { get; private set; }

    public float moveHorizontalInput { get; set; }
    public float MoveVerticalInput { get; set; }

    private void Awake()
    {
        Instance = this;
    }
}
