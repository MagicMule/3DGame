using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroNarativeText : MonoBehaviour
{
    void Start()
    {
        DialogueManger.Instance.NarativDialog(5);
    }

}
