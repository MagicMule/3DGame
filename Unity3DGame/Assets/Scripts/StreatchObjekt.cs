using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreatchObjekt : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(10f, 1f, 1f);
    public float scaleSpeed = 1f;

    public bool expand;

    private void Update()
    {
        ExpandObjektScale();
        ShrinkObjakteScale();
    }

    void ExpandObjektScale()
    {
        if(expand == true)
        {
            // Calculate the new scale based on the target scale and speed
            // localScale incres every update, scaleSpeed decreses the targetScale totoal making so more exextuons are nesesary to reace target 
            // Increas only the scale in x

            Vector3 newScale = transform.localScale + scaleSpeed * Time.deltaTime * new Vector3(targetScale.x, 0, 0);


            // Check if the new scale has reached or exceeded the target scale
            if (newScale.x >= targetScale.x && newScale.y >= targetScale.y && newScale.z >= targetScale.z)
            {
                //Stop expanding
                Debug.Log("Stop expanding");
            }
            else
            {
                // Update the scale
                transform.localScale = newScale;
            }
        }

    }

    void ShrinkObjakteScale()
    {
        if (expand == false)
        {
            Vector3 newScale = transform.localScale - (1 / scaleSpeed) * Time.deltaTime * new Vector3(targetScale.x, 0, 0);


            // Check if the new scale has reached or exceeded the target scale
            if (newScale.x <= targetScale.x && newScale.y <= targetScale.y && newScale.z <= targetScale.z)
            {
                //Stop expanding
                Debug.Log("Stop shrinking");
            }
            else
            {
                // Update the scale
                transform.localScale = newScale;
            }
        }


    }

}
