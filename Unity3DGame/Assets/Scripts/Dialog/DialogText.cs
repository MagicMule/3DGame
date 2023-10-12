using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogText : MonoBehaviour
{
    [System.Serializable]
    public class Dialog
    {
        public List<string> line;
    }

    //intro
    public Dialog dilogLinesA;
    //Start of level
    public Dialog dilogLinesB;
    public Dialog dilogLinesC;
    public Dialog dilogLinesD;
    public Dialog dilogLinesE;
    public Dialog dilogLinesF;


    void Start()
    {
        DialogA();
        DialogB();
        DialogC();


    }

    void DialogA()
    {
        dilogLinesA.line.Add("...");
        dilogLinesA.line.Add("How are you feeling?");
        dilogLinesA.line.Add("How should I feel? I'm as I have been. Don't worry, Im am but ready");
        dilogLinesA.line.Add("Truly? I have not made that demand of you, only ask if you are willing. You have experience, friends and knowledge and power. But you will dwell in a place where flesh and blood is law.");
        dilogLinesA.line.Add("Indeed. I have my contacts. Some are in me now and will follow me to Arums shores, others linger behind the moon and in the gleam of the stars. They will serve me as I have served them, by law.");
        dilogLinesA.line.Add("Laws, is it? Arum is a land where people make their own law. Are you sure a sneak will not cross and deny you?");
        dilogLinesA.line.Add("No, but that is the why of things. If in truth I have but my will and a drop of blood, it will have to do");
        dilogLinesA.line.Add("Not to worry, I have some to give you. The tip of the spear were forged in the Diamond Spring. It is the arm against the Yog-agl. You already know its name.");
    }

    void DialogB()
    {
        dilogLinesB.line.Add("This place is now of old cosality. The stink of the Yog-agl subtel asail, of evil. The place and time is corrypted. The sorce, the lord, must i find and drag they out of the world and back to the nothing truth of there making");
    }

    void DialogC()
    {
        dilogLinesC.line.Add ("From Erui firstborn woods, through the land of crashing down, come Syls Glare to smite from one hand!");
        dilogLinesC.line.Add("By the arms of Odion, the earth-bound giant, grant me thy Spear, a grueling boon against the Yog-agl!");
        dilogLinesC.line.Add("Glim and see, from land and sea, the With Dwarf Of Circle Valy. Enter through the veil of space and come to light my way!");
    }
}
