using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshMonitor : MonoBehaviour
{
    Transform playerCamTransform; // Stores the FPS camera transform
    private bool visible = true;
    private float distanceToAppear = 100;
    Renderer[] objRenderer;

    GameObject[] childObjekts;

    private void Start()
    {
        playerCamTransform = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>().transform;//Get camera transform reference
        objRenderer = gameObject.GetComponentsInChildren<Renderer>(); //Get render reference
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


                    renderer.enabled = true; // Show Object
                    visible = true;
                    Debug.Log("Visible");
                }
            }
        }
        else if (visible)
        {
            foreach (Renderer renderer in objRenderer)
            {
                renderer.enabled = false; // Hide Object
                visible = false;
                Debug.Log("InVisible");
            }
        }
    }
}
