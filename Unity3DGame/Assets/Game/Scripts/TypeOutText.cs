using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.TextCore.Text;

public class TypeOutText : MonoBehaviour
{
    private TextMeshProUGUI textInUI;

    private string textToTypeOut;

    public float typeOutTextSpeed;


    // Start is called before the first frame update
    void Start()
    {
        textInUI = GetComponent<TextMeshProUGUI>();
        textInUI.text = "";

        StartCoroutine(StartTypingText());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartTypingText()
    {
        string charaktersOfStrings = textToTypeOut;

        charaktersOfStrings = "Byrgenwerth... Byrgenwerth... Blasphemous murderers... Blood-crazed fiends... Atonement for the wretches... By the wrath of Mother Kos...Mercy for the poor, wizened child... Mercy, oh please...";
        foreach (char charakter in charaktersOfStrings)
        {
            textInUI.text = textInUI.text + charakter;
            Debug.Log(textInUI.text);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
