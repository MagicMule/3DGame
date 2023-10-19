using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlashingText : MonoBehaviour
{
    private TextMeshProUGUI textComponents;

    public float cangeColorFrequency;

    private void Start()
    {
        textComponents = GetComponent<TextMeshProUGUI>();

        InvokeRepeating(nameof(RandomColor), 0.1f, cangeColorFrequency);

    }

    void RandomColor() //Generate random collor
    {
        float RandomColor1;
        float RandomColor2;
        float RandomColor3;
        RandomColor1 = Random.Range(0.0f, 1.0f);
        RandomColor2 = Random.Range(0.0f, 1.0f);
        RandomColor3 = Random.Range(0.0f, 1.0f);

        textComponents.color = new Color(RandomColor1, RandomColor2, RandomColor3);

    }
}
