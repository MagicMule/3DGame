using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileInteract : MonoBehaviour
{
    /// <summary>
    /// How a missil fierd form the player will ackt
    /// </summary>

    public AudioClip missileClip;
    public float audioClipVolume = 0.1f;
    public bool missileTimeLimit = false;
    public float timeToDestoryed = 2f;
    // When the missile is instatiated
    private void Awake()
    {
        GameManager.Instance.PlayClipAt(missileClip, audioClipVolume, 1, transform.position); // Playe missile sound

        if (missileTimeLimit)
        {
            StartCoroutine(MissilePersistence());
        }
    }
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
            Destroy(gameObject); //Destory the projektile

            if (other.gameObject.GetComponent<Enemy>().HP <= 0) // Destory enemy
            {
                Destroy(other.gameObject);
            }
        }
    }
    IEnumerator MissilePersistence()
    {
        yield return new WaitForSeconds(timeToDestoryed);
        Destroy(gameObject);
    }
}
