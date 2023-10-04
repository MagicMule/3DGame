using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractCollider : MonoBehaviour
{
    /// <summary>
    /// This script is on the InteractCylinder gameobjekt
    /// The following are interactions that follow the gameobjekts colltion
    /// </summary>

    //public GameObject InteractUI;


    private void OnTriggerEnter(Collider other)
    {
        // Player interact with npc
        if (other.gameObject.CompareTag("NPC") && GameManager.Instance.InteractUIClosed)
        {

            GameManager.Instance.messigeToPlayer.gameObject.SetActive(true);

        }
        else if (other.gameObject && !GameManager.Instance.InteractUIClosed)
        {

            GameManager.Instance.messigeToPlayer.gameObject.SetActive(false);

            GameManager.Instance.InteractUIClosed = true; // UI is closed -> set interactUIClosed to True
        }


        // Player hit enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Play sound when player hit enemy
            AudioClip hitEnemySound = other.gameObject.GetComponent<Enemy>().enemyHitByPlayerAudioClip;
            GameManager.Instance.PlayClipAt(hitEnemySound, 1f, 3f, other.transform.position);

            // Damage Enemy
            other.gameObject.GetComponent<Enemy>().HP = GameManager.Instance.DecreaseHP(other.gameObject.GetComponent<Enemy>().HP, GameManager.Instance.meleeDamage); // hit enemy with 1 point of damage

            if (other.gameObject.GetComponent<Enemy>().HP <= 0) // Destory enemy
            {
                Destroy(other.gameObject);
            }

        }

        // Hit door objekt and the activet openCloseDoor, script on "doorHinge"
        if (other.gameObject.CompareTag("Door"))
        {
            other.gameObject.GetComponentInParent<OpenCloseDoor>().enabled = true;
        }

        if (other.gameObject.CompareTag("Lever"))
        {
            other.gameObject.GetComponentInParent<MoveLever>().enabled = true;
        }

        if (other.gameObject.CompareTag("EnemyProjektile"))
        {
           Debug.Log("Hit projektile");
           Destroy(other.gameObject);
        }



    }

}

