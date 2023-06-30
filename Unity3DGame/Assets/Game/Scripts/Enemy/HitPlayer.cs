using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    /// <summary>
    /// The damge done to player when attack is activated
    /// Cheks if there shuld be GameOver
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        int damge = GetComponentInParent<Enemy>().Damage;

        Debug.Log(damge);
        if (other.gameObject.CompareTag("Player") && !GameManager.Instance.gameOver)
        {

            PlayerHPManager.Instance.playerHP = DamageManager.Instance.DecreaseHP(PlayerHPManager.Instance.playerHP, damge); // cange playerHP to new value

            // call game over funkton
            if (PlayerHPManager.Instance.playerHP <= 0)
            {
                PlayerHPManager.Instance.PlayerGameOver();
            }
        }
    }
}
