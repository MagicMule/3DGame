using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreatchObjekt : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(2f, 2f, 2f);
    public float scaleSpeed = 1f;

    private void Update()
    {
        // Calculate the new scale based on the target scale and speed
        Vector3 newScale = transform.localScale + targetScale * scaleSpeed * Time.deltaTime;

        // Check if the new scale has reached or exceeded the target scale
        if (newScale.x >= targetScale.x && newScale.y >= targetScale.y && newScale.z >= targetScale.z)
        {
            // Clamp the scale to the exact target scale
            transform.localScale = targetScale;
        }
        else
        {
            // Update the scale
            transform.localScale = newScale;
        }
    }
}
