using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !PlayerHPManager.Instance.gameOver)
        {
            PlayerHPManager.Instance.PlayerDecreaseHP(1); // player takes damge

            Debug.Log(gameObject.name + " Hit " + other.gameObject.name);

            // call game over funkton
            if (PlayerHPManager.Instance.playerHP <= 0)
            {
                PlayerHPManager.Instance.PlayerGameOver();
            }
        }
    }
}
