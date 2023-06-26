using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{

    public int damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(damage);
        if (other.gameObject.CompareTag("Player") && !GameManager.Instance.gameOver)
        {

            PlayerHPManager.Instance.playerHP = DamageManager.Instance.DecreaseHP(PlayerHPManager.Instance.playerHP, damage); // cange playerHP to new value

            // call game over funkton
            if (PlayerHPManager.Instance.playerHP <= 0)
            {
                PlayerHPManager.Instance.PlayerGameOver();
            }
        }
    }
}
