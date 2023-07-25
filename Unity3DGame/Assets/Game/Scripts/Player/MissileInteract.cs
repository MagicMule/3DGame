using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileInteract : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lever"))
        {
            other.gameObject.GetComponentInParent<MoveLever>().enabled = true;
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Play sound when player hit enemy
            AudioClip hitEnemySound = other.gameObject.GetComponent<Enemy>().enemyHitByPlayerAudioClip;
            GameManager.Instance.PlayClipAt(hitEnemySound, 1f, 3f, other.transform.position);

            other.gameObject.GetComponent<Enemy>().HP = GameManager.Instance.DecreaseHP(other.gameObject.GetComponent<Enemy>().HP, GameManager.Instance.spellDamage1);
            
            Debug.Log(gameObject.name + " Hit " + other.gameObject.name);

            Destroy(gameObject);

            if (other.gameObject.GetComponent<Enemy>().HP <= 0) // Destory enemy
            {
                Destroy(other.gameObject);
            }
        }
    }
}
