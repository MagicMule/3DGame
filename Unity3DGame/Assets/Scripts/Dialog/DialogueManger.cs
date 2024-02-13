using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManger : MonoBehaviour
{

    /// <summary>
    /// Change and activate textobjekt, places were the dialog is to apair
    /// creating the visual of up to two charakters conversing
    /// Advance Dialog
    /// </summary>

    public static DialogueManger Instance;

    //Player Advance dialog input
    public KeyCode nextLine = KeyCode.Mouse0;
    public KeyCode NextLine => nextLine;

    //Dialog with two charaklters convesrins
    private int currentState = 0;  //inital sate
    public TextMeshProUGUI charakterDialog1;
    public TextMeshProUGUI charakterDialog2;
    public GameObject charakterDialogTextBackGround;
    public GameObject narativeTextBackGround;

    //Dialog of naration
    public TextMeshProUGUI narativDialog;

    //Spel verbal 
    public TextMeshProUGUI spellVerbal;
    public DialogText dialogText;
    private int dialogTextIndex = 0; //starting with the first line
    public List<GameObject> dilogInteractivObjekts; // things that spawn or other change based on dialog

    public bool narativBoxOpen = false;

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
        dialogText = GetComponent<DialogText>();
        if (CharacterControl.Instance != null)
        {
            NarativDialog(5);
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        // Player should be able to close dialog box thay have opend
        PlayerCloseDialog();

        // progration of charkter dialog
        ProgresCharakterDialog();

        // Deactavet text when typeout is complet
        CloseSpellText();
    }

    void PlayerCloseDialog()
    {
        if (narativBoxOpen && Input.GetKeyDown(GameManager.Instance.quitMenuKey))
        {
            narativDialog.gameObject.SetActive(false);
            narativeTextBackGround.SetActive(false);
            narativBoxOpen = false;
        }
    }
    void ProgresCharakterDialog()
    {
        if (Input.GetKeyDown(nextLine))
        {
            if (startDialogA)
            {
                OneOnOneDialog(dialogText.dilogLinesA);
            }

            else if (startDialogB)
            {
                OneOnOneDialog(dialogText.dilogLinesB);
            }

            else if (startDialogC)
            {
                OneOnOneDialog(dialogText.dilogLinesC);
            }
            else if (startDialogD)
            {
                OneOnOneDialog(dialogText.dilogLinesD);
            }
            else if (startDialogE)
            {
                OneOnOneDialog(dialogText.dilogLinesE);
            }
            else if (startDialogF)
            {
                OneOnOneDialog(dialogText.dilogLinesF);
            }
            else if (startDialogG)
            {
                OneOnOneDialog(dialogText.dilogLinesG);
            }
        }
    }

    void CloseSpellText()
    {
        if (CharacterControl.Instance != null)
        {
            if (spellVerbal.GetComponent<TypeOutText>().typeOutDone)
            {
                spellVerbal.gameObject.SetActive(false);
            }
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
        
        narativeTextBackGround.SetActive(true);
        narativDialog.gameObject.SetActive(false);
        narativDialog.GetComponent<TypeOutText>().textToTypeOut = dialogText.dialogLinesInteractives.line[dialogIndex];
        narativDialog.gameObject.SetActive(true);

        narativBoxOpen = true;

  
        /*
        StartCoroutine(DialogPrecistance( 20, narativDialog.gameObject)); // If player do not close, close text
        */
    }

    public void OneOnOneDialog(DialogText.Dialog dialogListToStart)
    {
        // Toggel between charakter1 and charakter2 dialog, as long as there is lines left in the dialoglist 
        // dialogTextIndex is keep track of wtich line is the aktive is at. 
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
                    charakterDialog1.gameObject.SetActive(true);
                    charakterDialog2.gameObject.SetActive(false);
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
            

            //Reset dialog bools
            startDialogA = false;
            startDialogB = false;
            startDialogC = false;
            startDialogD = false;
            startDialogE = false;
            startDialogF = false;
            startDialogG = false;
            //reset textIndex
            dialogTextIndex = 0;
            //reset state
            currentState = 0; 
            if (charakterDialogTextBackGround != null)
            {
                charakterDialogTextBackGround.SetActive(false);
            }



            if (CharacterControl.Instance != null)
            {
                charakterDialog1.gameObject.SetActive(false);
                charakterDialog2.gameObject.SetActive(false);
                CharacterControl.Instance.playerCanMove = true;
                CharacterControl.Instance.StopPlayerCameraMovment();
                StartCoroutine(DialogColdown());
            }
            
        }
    }

    IEnumerator DialogColdown()
    {
        yield return new WaitForSeconds(1);
        dialogIsActive = false;
    }

    // Things that happen based on line/ dialog prograsion
    void DialogEvent()
    {
        //Spawn spear
        // can only put in an indext that is less then or eqal to the total count of lines
        // if dilogTextIndex is greater then line.count it will not work
        if (!(dialogText.dilogLinesA.line.Count <= dialogTextIndex) 
            && dialogText.dilogLinesA.line[dialogTextIndex] == "Not to worry, I have some to give you. The tip of the spear were forged in the Diamond Spring. It is the arm against the Yog-agl."
            && startDialogA)
        {
            dilogInteractivObjekts[0].SetActive(true);
        }

        //Cange scen when intro interkton is done
        if (!(dialogText.dilogLinesA.line.Count <= dialogTextIndex)
            && dialogText.dilogLinesA.line[dialogTextIndex] == "...."
            && startDialogA)
        {
            SceneManager.LoadScene(2);
        }

        // desapwn Withround
        // *dilogInteractivObjekts[0] is now a difret objekt as it is in anopther scene
        if (!(dialogText.dilogLinesB.line.Count <= dialogTextIndex)
            && dialogText.dilogLinesB.line[dialogTextIndex] == "Aye, Aye!"
            && startDialogB)
        {
            dilogInteractivObjekts[0].SetActive(false);
            Debug.Log("Remove this");
        }

        //Deaktivate Sage1 and activate Sage2
        if (!(dialogText.dilogLinesC.line.Count <= dialogTextIndex)
            && dialogText.dilogLinesC.line[dialogTextIndex] == "I will return shortly. Hopefully."
            && startDialogC)
        {
            dilogInteractivObjekts[0].SetActive(false);
            dilogInteractivObjekts[1].SetActive(true);
            dilogInteractivObjekts[7].SetActive(true);
        }

        //Deaktivate Sage3 and activate Sage5
        //Sage give key
        if (!(dialogText.dilogLinesE.line.Count <= dialogTextIndex)
            && dialogText.dilogLinesE.line[dialogTextIndex] == "Goodbye."
            && startDialogE)
        {
            dilogInteractivObjekts[2].SetActive(false);
            dilogInteractivObjekts[6].SetActive(false);
            dilogInteractivObjekts[3].SetActive(true);
            PlayerInventory.Instance.key = true;
        }
        //Spear of Odion interaction
        // deactivet npc and activeaete piuckupp
        if (!(dialogText.dilogLinesG.line.Count <= dialogTextIndex)
            && dialogText.dilogLinesG.line[dialogTextIndex] == "I saw where you entered. On the same low ground, at the end of the complex, there is rubble and instability. Select me with the (2) key and fire with right click. I know for true that my power is grand, that it is to clear a path there. Let's break forth!!"
            && startDialogG)
        {
            dilogInteractivObjekts[4].SetActive(false);
            dilogInteractivObjekts[5].SetActive(true);
        }
        

    }
    //Set a timer on a dialog
    IEnumerator DialogPrecistance(int timeOut, GameObject dialogToTimeOut)
    {
        yield return new WaitForSeconds(timeOut);
        narativeTextBackGround.SetActive(false);
        dialogToTimeOut.SetActive(false);
    }
}
