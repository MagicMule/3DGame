using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeSorce : MonoBehaviour
{
    /// <summary>
    /// This script is aplyead generaly to objekts that damge all charaktere entitys, Enemy, Playe, etc.
    /// Aplyed on projektiles, player efekts/spells, traps
    /// </summary>
    // Start is called before the first frame update

    public int damgeNumber = 1;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        { 
            other.gameObject.GetComponent<Enemy>().HP = 
                GameManager.Instance.DecreaseHP(other.gameObject.GetComponent<Enemy>().HP, damgeNumber); 
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.playerHP = GameManager.Instance.DecreaseHP(GameManager.Instance.playerHP, damgeNumber);
        }
    }
}
