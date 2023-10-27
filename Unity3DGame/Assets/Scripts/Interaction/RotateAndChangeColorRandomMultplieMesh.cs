using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndChangeColorRandomMultplieMesh : MonoBehaviour
{
    /// <summary>
    /// Sumalar to RandomAndChangeColorRabdom
    /// Gets all the metarails on aplyed gamobjkts childern and cahnge color reapitatly
    /// 
    /// </summary>
    public int rotationSpeedX;
    public int rotationSpeedY;
    public int rotationSpeedZ;
    private MeshRenderer[] renderToChangeColor;
    public float cangeColorFrequency = 5f;
    public bool cangeCollorRandom = true;
    void Start()
    {
        renderToChangeColor = GetComponentsInChildren<MeshRenderer>(); // Get a list of all gamobjkts metrails

        //Cange color by given time
        if (cangeCollorRandom)
        {
            InvokeRepeating(nameof(RandomColor), 0.1f, cangeColorFrequency);
        }
        if (cangeCollorRandom)
        {
            foreach(MeshRenderer renderer in renderToChangeColor)
            {
                renderer.material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeedX * Time.deltaTime, rotationSpeedY * Time.deltaTime, rotationSpeedZ * Time.deltaTime);
    }
    void RandomColor() //Generate random collor
    {
        float RandomColor1;
        float RandomColor2;
        float RandomColor3;
        RandomColor1 = Random.Range(0.0f, 1.0f);
        RandomColor2 = Random.Range(0.0f, 1.0f);
        RandomColor3 = Random.Range(0.0f, 1.0f);

        foreach (MeshRenderer renderer in renderToChangeColor)
        {
            renderer.material.color = new Color(RandomColor1, RandomColor2, RandomColor3);
        }
    }
}
