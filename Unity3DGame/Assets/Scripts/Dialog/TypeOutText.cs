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

    public string textToTypeOut;

    public float textSpeed;


    // Start is called before the first frame update

    private void OnEnable()
    {
        textInUI = GetComponent<TextMeshProUGUI>();
        textInUI.text = "";
        StartCoroutine(StartTypingText());
        Debug.Log("Wake up");
    }

    IEnumerator StartTypingText()
    {
        string charaktersOfStrings = textToTypeOut;

        foreach (char charakter in charaktersOfStrings)
        {
            textInUI.text = textInUI.text + charakter;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(2);

        //this.gameObject.SetActive(false);
    }
}
