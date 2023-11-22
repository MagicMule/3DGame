using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMeshTrigger : MonoBehaviour
{
    public List<GameObject> gameOvjektsToDeActivate;
    public List<GameObject> gameOvjektsToActivate;
    // turn of all gameobjkts in the list apon pplayer colitons
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject aG in gameOvjektsToDeActivate) 
            {
                if(aG != null)
                {
                    aG.SetActive(false);
                }
            }

            foreach (GameObject dG in gameOvjektsToActivate)
            {
                if(dG != null)
                {
                    dG.SetActive(true);
                }
            }
        }
    }
}
