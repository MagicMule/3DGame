using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public bool godHand = false;
    public bool spear = false;
    public bool key = false;
    public bool spel1 = false;  
    public bool spel2 = false;
    public bool spel3 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GodHand"))
        {
            godHand = true;
            Destroy(other.gameObject);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
