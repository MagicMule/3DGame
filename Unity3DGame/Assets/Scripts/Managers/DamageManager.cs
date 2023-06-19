using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager Instance;


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
}
