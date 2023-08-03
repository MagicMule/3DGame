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

    public GameObject[] missile;
    public GameObject missileAttackPos;
    public int spellSelected = 0;

    private Vector3 missileAttackPosOffset = new (0, 0, 0); //Positon
    private Vector3 missileAttackRotOffset = new (1, 1, 1); //Rotation

    public AudioClip missileAttackSound;


    private void Start()
    {
        CangeMissileOffset();
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
        Instantiate(missile[spellSelected], missileAttackPos.transform.position, missileAttackPos.transform.rotation);

        yield return new WaitForSeconds(missileAttackDeley); // Time befor player can make onather missile attack

        missileAttackReady = true;
    }

    public void CangeMissileOffset()
    {
        if (missile[spellSelected].CompareTag("Spell 1"))
        {
            missileAttackPosOffset = new(0, 0, 0);
            missileAttackRotOffset = new(1, 1, 1);

        }

        else if (missile[spellSelected].CompareTag("Spell 2"))
        {
            missileAttackPosOffset = new(0.5f, 0.5f, 0);
            missileAttackRotOffset = new(1, 45, 5);

            Debug.Log("Shot: " + missile[spellSelected].name);
        }

        else if (missile[spellSelected].CompareTag("Spell 3"))
        {
            missileAttackPosOffset = new(0, 0, 0);
            missileAttackRotOffset = new(1, 1, 1);
        }
    }

    public void CangeSpell()
    {
        if(Input.GetKeyDown(GameManager.Instance.hotKeyInput1))
        {
            Debug.Log( missile[0] + " selekted");
        }

        if (Input.GetKeyDown(GameManager.Instance.hotKeyInput2))
        {
            Debug.Log(missile[1] + " selekted");
        }

        if (Input.GetKeyDown(GameManager.Instance.hotKeyInput3))
        {
            Debug.Log(missile[2] + " selekted");
        }
    }
}
