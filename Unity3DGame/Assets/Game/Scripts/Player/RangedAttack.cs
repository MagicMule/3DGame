using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    /// <summary>
    /// This script Shot out a loaded missile or efekt (on missileAttackPos)
    /// </summary>

    //Missile
    public bool missileAttackReady = true;
    public float missileAttackDeley = 0.5f;
    public float missileAttackDuration = 0.2f;

    //public AudioClip missileAttackSound;
    //public float missileAttackSoundVolume = 1.0f;

    public GameObject missile;
    public GameObject missileAttackPos;

    public Vector3 missileAttackPosOffset = new (0, 0, 0);
    public Vector3 missileAttackRotOffset = new (1, 1, 1) ;

    public AudioClip missileAttackSound;


    private void Start()
    {
        //Apply offset to range attack
        missileAttackPos.transform.position = missileAttackPos.transform.position + missileAttackPosOffset;
        missileAttackPos.transform.rotation = missileAttackPos.transform.rotation * Quaternion.Euler(missileAttackRotOffset); //Cange Deg
    }

    private void Update()
    {
        ShotMissile();
    }

    // Instansate Missile, att missle prefab postion
    void ShotMissile()
    {
        if (Input.GetKeyDown(GameManager.Instance.missileKey) && missileAttackReady)
        {
            StartCoroutine(MissileAttack());
        }
    }

    // missile instasiate at missileAttackPos
    IEnumerator MissileAttack()
    {

        missileAttackReady = false;
        Instantiate(missile, missileAttackPos.transform.position, missileAttackPos.transform.rotation);

        yield return new WaitForSeconds(missileAttackDeley); // Time befor player can make onather missile attack

        missileAttackReady = true;
    }
}
