using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitPlayer : Enemy
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !GameManager.Instance.gameOver)
        {

            PlayerHPManager.Instance.playerHP = DamageManager.Instance.DecreaseHP(PlayerHPManager.Instance.playerHP, Damage); // cange playerHP to new value

            // call game over funkton
            if (PlayerHPManager.Instance.playerHP <= 0)
            {
                PlayerHPManager.Instance.PlayerGameOver();
            }
        }
    }
}
