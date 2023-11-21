using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractTrigger : MonoBehaviour
{
    // activate this gameObjekt on player interaction
    public GameObject openPortal;
    public List<GameObject> astralPlane;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerMeleeAttack"))
        {
            StartCoroutine(WhaitForSpellVerbal());
        }
    }

    IEnumerator WhaitForSpellVerbal()
    {
        yield return new WaitForSeconds(5);
        openPortal.SetActive(false);
        astralPlane[0].SetActive(true);
        astralPlane[1].SetActive(true);
    }
}
