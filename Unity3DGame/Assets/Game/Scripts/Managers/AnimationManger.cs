using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationManger : MonoBehaviour
{
    public static AnimationManger Instance;

    public AnimatorController spearAttack;
    public AnimatorController SpearAttack => spearAttack;

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
