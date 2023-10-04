using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBeam : MonoBehaviour
{
    /// <summary>
    /// Efekt of the missleBeam spell
    /// </summary>
    public GameObject repeatingEffekt;
    private Transform missileAttackPos;
    public Vector3 missileAttackPosOffset;
    public Quaternion missileAttackRotOffset;
    public float repeatDelay = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(ActivateEffekt), 0, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        missileAttackPos = GameObject.FindGameObjectWithTag("PlayerSpellPos").transform;
    }

    public void ActivateEffekt()
    {
        if (missileAttackPos != null)
        {
            _ = Instantiate(repeatingEffekt, 
                missileAttackPos.transform.position + missileAttackPosOffset, missileAttackPos.transform.rotation * missileAttackRotOffset);
        }
    }

}
