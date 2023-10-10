using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public static DialogueManger Instance;

    public KeyCode nextLine = KeyCode.Mouse0;
    public KeyCode NextLine => nextLine;

    //Dialog with two charaklters convesrins
    private int currentState = 0;  //inital sate
    public TextMeshProUGUI charakterDialog1;
    public TextMeshProUGUI charakterDialog2;
    private TextMeshProUGUI currentCharakterDialog;

    //Dialog of naration
    public TextMeshProUGUI narativDialog;


    private DialogText dialogText;

    private int dialogTextIndex = 0; //starting with the first line

    public List<GameObject> dilogInteractivObjekts; // things that spawn or other change based on dialog

    public bool startDialogA = false;
    public bool startDialogB = false;
    public bool startDialogC = false;
    public bool startDialogD = false;
    public bool startDialogE = false;
    public bool startDialogF = false;
    public bool startDialogG = false;
    public bool startDialogh = false;

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
            if (startDialogA)
            {

                OneOnOneDialog(dialogText.dilogLinesA);
            }

            else if (startDialogB)
            {
                NarativDialog(dialogText.dilogLinesB);
            }

        }


    }


    public void spellVerbalDialog()
    {
        if (dialogTextIndex < dialogText.dilogLinesC.line.Count)
        {
            narativDialog.gameObject.SetActive(false);

            narativDialog.GetComponent<TypeOutText>().textToTypeOut = dialogText.dilogLinesC.line[dialogTextIndex];

            dialogTextIndex += 1; // Continue to next line
            narativDialog.gameObject.SetActive(true);
        }
    }

    void NarativDialog(DialogText.Dialog activeDialog)
    {

        if (dialogTextIndex < activeDialog.line.Count)
        {
            narativDialog.gameObject.SetActive(false);

            narativDialog.GetComponent<TypeOutText>().textToTypeOut = activeDialog.line[dialogTextIndex];

            dialogTextIndex += 1; // Continue to next line
            narativDialog.gameObject.SetActive(true);
        }
        else
        {
            narativDialog.gameObject.SetActive(false);
        }
    }


    void OneOnOneDialog(DialogText.Dialog activeDialog)
    {
        // Toggel between charakter1 and charakter2 dialog
        if (dialogTextIndex < activeDialog.line.Count)
        {
            switch (currentState)
            {
                //charkter 1 talk
                case 0:

                    if (dialogTextIndex < activeDialog.line.Count)
                    {
                        charakterDialog1.GetComponent<TypeOutText>().textToTypeOut = activeDialog.line[dialogTextIndex]; // Get line from DilogText

                        DialogEvent();

                        dialogTextIndex += 1; // Continue to next line
                    }



                    charakterDialog2.gameObject.SetActive(false);

                    currentCharakterDialog = charakterDialog1;

                    currentCharakterDialog.gameObject.SetActive(true);

                    currentState = 1;


                    break;

                //Charkater 2 talk
                case 1:

                    if (dialogTextIndex < activeDialog.line.Count)
                    {
                        charakterDialog2.GetComponent<TypeOutText>().textToTypeOut = activeDialog.line[dialogTextIndex];

                        DialogEvent();

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

    // Things that happen based on line/ dialog prograsion
    void DialogEvent()
    {
        //Spawn spear
        if (dialogText.dilogLinesA.line[dialogTextIndex] == "Not to worry, I have some to give you. The tip of the spear were forged in the Diamond Spring. It is the arm against the Yog-agl. You already know its name.")
        {
            dilogInteractivObjekts[0].SetActive(true);
        }



    }

}
