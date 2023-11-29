using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractTrigger : MonoBehaviour
{
    // activate this gameObjekt on player interaction
    public List<GameObject> objektsToAvtivate;
    public List<GameObject> objektsToDactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerMeleeAttack"))
        {
            StartCoroutine(ActivateAndDeActivate());
        }
    }

    IEnumerator ActivateAndDeActivate()
    {
        yield return new WaitForSeconds(5); // Time befor change happens

        foreach (GameObject ob in objektsToAvtivate)
        {
            ob.SetActive(true);
        }

        foreach (GameObject ob in objektsToDactivate)
        {
            ob.SetActive(false);
        }
    }
}
