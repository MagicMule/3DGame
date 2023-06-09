using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StreatchObjekt : MonoBehaviour
{
    /// <summary>
    /// This canges an objekts scale in game time, creating an expanbding efekt
    /// </summary>
    public Vector3 targetScale = new Vector3(10f, 1f, 1f);

    public float scaleSpeed = 1f;

    public float tilingIncreseRate = 1f; //The incres of the tailing of the cangin objekts textrue
    private Renderer objectRenderer;
    private Vector2 initialTiling = new Vector2(5, 2);

    public bool expand;

    private void Start()
    {
        objectRenderer = GetComponentInChildren<Renderer>();
    }



    private void Update()
    {
        ExpandObjektScale();
        ShrinkObjakteScale();
        KeepTilingConsistnat();
    }




    void ExpandObjektScale()
    {
        if(expand == true)
        {
            // Calculate the new scale based on the target scale and speed
            // localScale incres every update, scaleSpeed decreses the targetScale totoal, so more updates are nesesary to reace targetScale
            // Increas only the scale in x

            Vector3 newScale = transform.localScale + scaleSpeed * Time.deltaTime * new Vector3(targetScale.x, 0, 0);


            // Check if the new scale has reached or exceeded the target scale
            if (newScale.x >= targetScale.x && newScale.y >= targetScale.y && newScale.z >= targetScale.z)
            {
                //Stop expanding
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
            }
            else
            {
                // Update the scale
                transform.localScale = newScale;

            }
        }
    }

    // keep Tiling consistant on X
    void KeepTilingConsistnat()
    {
        Vector2 currentTiling = new Vector2(initialTiling.x + transform.localScale.x * tilingIncreseRate, initialTiling.y); // Cange Tiling scale X relative to objekt scale on X

        objectRenderer.sharedMaterial.mainTextureScale = currentTiling;

        Debug.Log(currentTiling);
    }

    // return the scale to orignal value
    private void OnApplicationQuit()
    {
        objectRenderer.sharedMaterial.mainTextureScale = new Vector2(5, 2);
    }
}
