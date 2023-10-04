using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManger : MonoBehaviour
{

    public KeyCode nextLine = KeyCode.Mouse0;
    public KeyCode NextLine => nextLine;


    private int currentState = 0;  //inital sate

    public TextMeshProUGUI charakterDialog1;
    public TextMeshProUGUI charakterDialog2;

    private TextMeshProUGUI currentCharakterDialog;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(nextLine))
        {
            Debug.Log("nextLine");
            PlayerControlDialog();
        }
    }

    void PlayerControlDialog()
    {
        // Toggel between charakter1 and charakter2 dialog

        switch (currentState)
        {
            case 0:

                charakterDialog2.gameObject.SetActive(false);

                currentCharakterDialog = charakterDialog1;

                currentCharakterDialog.gameObject.SetActive(true);

                currentState = 1;
                break;

            case 1:

                charakterDialog1.gameObject.SetActive(false);

                currentCharakterDialog = charakterDialog2;

                currentCharakterDialog.gameObject.SetActive(true);

                currentState = 0;
                break;

        }
    }


}
