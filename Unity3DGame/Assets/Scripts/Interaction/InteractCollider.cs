using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractCollider : MonoBehaviour
{
    /// <summary>
    /// This script is on the InteractCylinder gameobjekt atached to the Player
    /// The following are interactions that follow the gameobjekts colltion
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        if (!DialogueManger.Instance.dialogIsActive)// interakton only available if game not in "Dialog Mode"
        {
            DialogInteraction(other);
            AttackInteraction(other);
        }
    }

    void AttackInteraction(Collider other)
    {
        //if using attack
        if (CharacterControl.Instance.interactionModeAttack)
        {
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
        }
    }

    //

    void DialogInteraction(Collider other)
    {
        // if using interaktion
        if (CharacterControl.Instance.interactionModeInteract)
        {
            if (other.gameObject.CompareTag("Interactive1"))
            {
                Debug.Log("1");
                DialogueManger.Instance.NarativDialog(0);
            }
            else if (other.gameObject.CompareTag("Interactive2"))
            {
                Debug.Log("2");
                DialogueManger.Instance.NarativDialog(1);
            }
            else if (other.gameObject.CompareTag("Interactive3"))
            {
                Debug.Log("3");
                DialogueManger.Instance.NarativDialog(3);
            }
            else if (other.gameObject.CompareTag("Interactive4"))
            {
                Debug.Log("4");
                DialogueManger.Instance.NarativDialog(4);
            }

            // Player interact with npc
            if (other.gameObject.CompareTag("NPC1"))
            {
                DialogueManger.Instance.startDialogA = false;
                DialogueManger.Instance.startDialogC = false;

                DialogueManger.Instance.charakterDialogTextBackGround.SetActive(true);
                DialogueManger.Instance.startDialogB = true; //Enambel dialogB
                DialogueManger.Instance.OneOnOneDialog(DialogueManger.Instance.dialogText.dilogLinesB); //start dialogB
            }


            if (other.gameObject.CompareTag("NPC2"))
            {
                DialogueManger.Instance.startDialogA = false;
                DialogueManger.Instance.startDialogB = false;

                DialogueManger.Instance.charakterDialogTextBackGround.SetActive(true);
                DialogueManger.Instance.startDialogC = true; //Enambel dialogB
                DialogueManger.Instance.OneOnOneDialog(DialogueManger.Instance.dialogText.dilogLinesC); //start dialogC
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
}

