using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MeshMonitor : MonoBehaviour
{
    Transform playerCamTransform; // Stores the FPS camera transform
    private bool visible = true;
    private float distanceToAppear = 50;
    List<Renderer> objRenderer;

    private void Start()
    {
        playerCamTransform = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>().transform; // Get camera transform reference
        UpdateRendererReferences(); // Initial update of renderer references
    }

    private void Update()
    {
        DisappearChecker();
    }

    private void DisappearChecker()
    {
        float distance = Vector3.Distance(playerCamTransform.position, transform.position);

        // We have reached the distance to Enable Object
        if (distance < distanceToAppear)
        {
            if (!visible)
            {
                foreach (Renderer renderer in objRenderer)
                {
                    if (renderer != null)
                    {
                        renderer.enabled = true; // Show Object
                    }

                }
                visible = true;
                Debug.Log("Visible");
            }
        }
        else if (visible)
        {
            foreach (Renderer renderer in objRenderer)
            {
                if (renderer != null)
                {

                    renderer.enabled = false; // Hide Object
                }
            }
            visible = false;
            Debug.Log("InVisible");
        }
    }

    // Call this method after re-enabling the object to update the references
    private void UpdateRendererReferences()
    {
        objRenderer = new List<Renderer>();
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            if (renderer != null)
            {
                objRenderer.Add(renderer);
            }
        }
    }
}
