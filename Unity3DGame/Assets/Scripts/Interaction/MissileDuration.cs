using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileDuration : MonoBehaviour
{
    /// <summary>
    /// This is used to destoy a gameovjekt that has ben instatioated after sed dely
    /// </summary>

    public float deley = 0.1f;


    private void Awake()
    {
        StartCoroutine(DurationOFEffekt());
    }

    IEnumerator DurationOFEffekt()
    {
        yield return new WaitForSeconds(deley);

        Destroy(gameObject);
    }
}
