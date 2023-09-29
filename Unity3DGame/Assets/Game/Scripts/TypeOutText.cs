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
    /// <summary>
    /// Get the text of objekt atached to, write out text given in variable "textToTypeOut", on charakter at the time
    /// </summary>

    private TextMeshProUGUI textInUI;

    private string textToTypeOut;

    public float textSpeed;


    // Start is called before the first frame update
    void Start()
    {
        textInUI = GetComponent<TextMeshProUGUI>();
        textInUI.text = "";
        StartCoroutine(StartTypingText());

    }

    IEnumerator StartTypingText()
    {
        string charaktersOfStrings = textToTypeOut;

        charaktersOfStrings = "Byrgenwerth... Byrgenwerth... Blasphemous murderers... Blood-crazed fiends... Atonement for the wretches... By the wrath of Mother Kos...Mercy for the poor, wizened child... Mercy, oh please...";
        foreach (char charakter in charaktersOfStrings)
        {
            textInUI.text = textInUI.text + charakter;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
