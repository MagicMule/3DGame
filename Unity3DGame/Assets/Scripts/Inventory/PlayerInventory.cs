using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

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

    public bool godHand = false;
    public bool spear = false;
    public bool key = false;
    public bool spel1 = false;  
    public bool spel2 = false;
    public bool spel3 = false;

}
