using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBallSpell : MonoBehaviour
{
    private Transform lightPos;
    void Update()
    {
        lightPos = GameManager.Instance.MainCameraTrans;

        transform.position = lightPos.transform.position + new Vector3(-0.5f, 0, 1f);
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
