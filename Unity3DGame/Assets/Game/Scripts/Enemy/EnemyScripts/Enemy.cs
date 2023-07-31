using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform PlayerPos;

    public int HP;

    public int Damage;

    public float Speed;

    public float AgroRange;

    private AudioSource enemyAudioSource;

    public AudioClip enemyHitByPlayerAudioClip;

    private void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Some sorce of mic damage, not from player
        if (other.gameObject.CompareTag("Damage"))
        {
            HP = GameManager.Instance.DecreaseHP(HP, 1); // hit enemy with 1 point of damage

            Destroy(other.gameObject);

            if (HP <= 0) // Destory enemy
            {
                Destroy(gameObject);
            }

        }
    }

}
