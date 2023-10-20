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
    public GameObject charakterDialogTextBackGround;

    //Dialog of naration
    public TextMeshProUGUI narativDialog;

    //Spel verbal 
    public TextMeshProUGUI spellVerbal;
    public DialogText dialogText;
    private int dialogTextIndex = 0; //starting with the first line
    public List<GameObject> dilogInteractivObjekts; // things that spawn or other change based on dialog
    private bool dialogInteractiveObjektsFound = false;

    public bool startDialogA = false;
    public bool startDialogB = false;
    public bool startDialogC = false;
    public bool startDialogD = false;
    public bool startDialogE = false;
    public bool startDialogF = false;
    public bool startDialogG = false;
    public bool dialogIsActive; // keep trank on witch bool is active

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
        FindDialogInteractiveObjeks();
        dialogText = GetComponent<DialogText>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!dialogInteractiveObjektsFound)
        {
            FindDialogInteractiveObjeks();
        }
        // progration of charkter dialog
        if (Input.GetKeyDown(nextLine))
        {
            if (startDialogA)
            {
                dialogIsActive = true; //Mark that game is in "Dialog mode"
                OneOnOneDialog(dialogText.dilogLinesA);
            }

            else if (startDialogB)
            {
                dialogIsActive = true;
                OneOnOneDialog(dialogText.dilogLinesB);
            }

            else if (startDialogC)
            {
                dialogIsActive = true;
                OneOnOneDialog(dialogText.dilogLinesC);
            }
        }
        // Deactavet text when typeout is complet
        if (spellVerbal.GetComponent<TypeOutText>().typeOutDone)
        {
            spellVerbal.gameObject.SetActive(false);
        }
    }

    // chose what inedect to use when spell is cast
    public void SpellVerbalDialog(int spelIndex)
    {
        Debug.Log(spellVerbal.GetComponent<TypeOutText>().typeOutDone);
        if(spellVerbal.GetComponent<TypeOutText>().typeOutDone)
        {
            spellVerbal.GetComponent<TypeOutText>().textToTypeOut = dialogText.dialogLinesSpellVerbal.line[spelIndex];
            spellVerbal.gameObject.SetActive(true);
        }
    }

    public void NarativDialog(int dialogIndex)
    {
        narativDialog.gameObject.SetActive(false);
        narativDialog.GetComponent<TypeOutText>().textToTypeOut = dialogText.dialogLinesInteractives.line[dialogIndex];
        narativDialog.gameObject.SetActive(true);
        StartCoroutine(DialogPrecistance( 3, narativDialog.gameObject));
    }

    public void OneOnOneDialog(DialogText.Dialog dialogListToStart)
    {
        // Toggel between charakter1 and charakter2 dialog 
        if (dialogTextIndex < dialogListToStart.line.Count)
        {
            switch (currentState)
            {
                //charkter 1 talk
                case 0:
                    if (dialogTextIndex < dialogListToStart.line.Count)
                    {
                        charakterDialog1.GetComponent<TypeOutText>().textToTypeOut = dialogListToStart.line[dialogTextIndex]; // Get line from DilogText
                        DialogEvent();
                        dialogTextIndex += 1; // Continue to next line
                    }
                    charakterDialog2.gameObject.SetActive(false);
                    charakterDialog1.gameObject.SetActive(true);
                    currentState = 1;
                    break;
                //Charkater 2 talk
                case 1:
                    if (dialogTextIndex < dialogListToStart.line.Count)
                    {
                        charakterDialog2.GetComponent<TypeOutText>().textToTypeOut = dialogListToStart.line[dialogTextIndex];
                        DialogEvent();
                        dialogTextIndex += 1; // Continue to next line
                    }
                    charakterDialog1.gameObject.SetActive(false);
                    charakterDialog2.gameObject.SetActive(true);
                    currentState = 0;
                    break;
            }
        }
        else
        {
            //mark that game has left "Dialog Mode"
            dialogIsActive = false;
            //Reset dialog bools
            startDialogA = false;
            startDialogB = false;
            startDialogC = false;
            //reset textIndex
            dialogTextIndex = 0;
            if (charakterDialogTextBackGround != null)
            {
                charakterDialogTextBackGround.SetActive(false);
            }
            charakterDialog1.gameObject.SetActive(false);
            charakterDialog2.gameObject.SetActive(false);
        }
    }
    // Things that happen based on line/ dialog prograsion
    void DialogEvent()
    {
        //Spawn spear
        // can only put in an indext that is less then or eqal to the total count of lines
        // if dilogTextIndex is greater then line.count it will not work
        if (!(dialogText.dilogLinesA.line.Count <= dialogTextIndex) 
            && dialogText.dilogLinesA.line[dialogTextIndex] == "Not to worry, I have some to give you. The tip of the spear were forged in the Diamond Spring. It is the arm against the Yog-agl. You already know its name." 
            && startDialogA)
        {
            dilogInteractivObjekts[0].SetActive(true);
        }

        // desapwn Withround
        // *dilogInteractivObjekts[0] is now a difret objekt as it is in anopther scene
        if (!(dialogText.dilogLinesB.line.Count <= dialogTextIndex)
            && dialogText.dilogLinesB.line[dialogTextIndex] == "Aye, Aye!"
            && startDialogB)
        {
            dilogInteractivObjekts[0].SetActive(false);
        }
    }
    //Set a timer on a dialog
    IEnumerator DialogPrecistance(int timeOut, GameObject dialogToTimeOut)
    {
        yield return new WaitForSeconds(timeOut);
        dialogToTimeOut.SetActive(false);
    }
    // Find the ibjekts that ist to cange in realtion to dialog
    // and add them to the list
    public void FindDialogInteractiveObjeks()
    {
        if(GameObject.FindGameObjectWithTag("NPC1") != null)
        {
            dialogInteractiveObjektsFound = true;
            Debug.Log("find");
            dilogInteractivObjekts.Add(GameObject.FindGameObjectWithTag("NPC1"));
        }
        
    }

}
