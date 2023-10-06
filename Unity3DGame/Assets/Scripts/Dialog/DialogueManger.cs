using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DialogueManger : MonoBehaviour
{

    /// <summary>
    /// Change and activate textobjekt, places were the dialog is to apair
    /// creating the visual of up to two charakters conversing
    /// Advance Dialog
    /// </summary>

    public KeyCode nextLine = KeyCode.Mouse0;
    public KeyCode NextLine => nextLine;


    private int currentState = 0;  //inital sate

    public TextMeshProUGUI charakterDialog1;
    public TextMeshProUGUI charakterDialog2;

    private TextMeshProUGUI currentCharakterDialog;

    private DialogText dialogText;
    private int dialogTextIndex = 0; //starting with the first line

    // Start is called before the first frame update
    void Start()
    {
        dialogText = GetComponent<DialogText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(nextLine))
        {
            PlayerControlDialog();
        }
    }

    void PlayerControlDialog()
    {
        // Toggel between charakter1 and charakter2 dialog
        if (dialogTextIndex < dialogText.dilogLinesA.line.Count)
        {
            switch (currentState)
            {
                //charkter 1 talk
                case 0:

                    if (dialogTextIndex < dialogText.dilogLinesA.line.Count)
                    {
                        charakterDialog1.GetComponent<TypeOutText>().textToTypeOut = dialogText.dilogLinesA.line[dialogTextIndex];
                        dialogTextIndex += 1; // Continue to next line
                    }



                    charakterDialog2.gameObject.SetActive(false);

                    currentCharakterDialog = charakterDialog1;

                    currentCharakterDialog.gameObject.SetActive(true);

                    currentState = 1;


                    break;

                //Charkater 2 talk
                case 1:

                    if (dialogTextIndex < dialogText.dilogLinesA.line.Count)
                    {
                        charakterDialog2.GetComponent<TypeOutText>().textToTypeOut = dialogText.dilogLinesA.line[dialogTextIndex];
                        dialogTextIndex += 1; // Continue to next line
                    }



                    charakterDialog1.gameObject.SetActive(false);

                    currentCharakterDialog = charakterDialog2;

                    currentCharakterDialog.gameObject.SetActive(true);




                    currentState = 0;



                    break;

            }
        }
        else
        {
            charakterDialog1.gameObject.SetActive(false);
            charakterDialog2.gameObject.SetActive(false);
        }

    }


}
