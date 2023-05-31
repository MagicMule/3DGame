using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjekt : MonoBehaviour
{
    public Transform ObjektToRotate;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.Rotate(0, 0, 1);
    }
}
