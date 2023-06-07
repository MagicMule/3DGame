using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeObjektManager : MonoBehaviour

{
    /// <summary>
    /// The is to manage objekts and there realtion, distance to each outer
    /// </summary>
    /// 
    public static RelativeObjektManager Instance { get; private set; }
    


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
