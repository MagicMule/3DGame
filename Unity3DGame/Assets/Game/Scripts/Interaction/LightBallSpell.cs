using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBallSpell : MonoBehaviour
{
    public Vector3 lightPosOffset;
    private Transform lightPos;
    void Update()
    {
        lightPos = GameManager.Instance.MainCameraTrans;

        transform.position = lightPos.transform.position + lightPosOffset;
        transform.rotation = lightPos.transform.rotation;

        if(Input.GetKeyDown(GameManager.Instance.missileKey))
        {
            foreach ( GameObject lightSpell in GameObject.FindGameObjectsWithTag("Spell 3"))
            {
                Destroy(lightSpell);
            }
        }
    }
}
 