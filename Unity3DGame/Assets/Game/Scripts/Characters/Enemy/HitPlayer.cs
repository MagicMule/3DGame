using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    /// <summary>
    /// The damge done to player when attack is activated
    /// Cheks if there shuld be GameOver
    /// to be used by traps and enemys
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        int damge = GetComponentInParent<Enemy>().Damage;

        if (other.gameObject.CompareTag("Player") && !GameManager.Instance.gameOver)
        {
            Debug.Log("Enemy Hit player");
            GameManager.Instance.playerHP = GameManager.Instance.DecreaseHP(GameManager.Instance.playerHP, damge); // cange playerHP to new value

            // call game over funkton
            if (GameManager.Instance.playerHP <= 0)
            {
                Debug.Log("Game over");
                GameManager.Instance.PlayerGameOver();
            }
        }
    }
}
