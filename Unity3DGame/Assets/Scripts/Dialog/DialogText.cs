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
    public Dialog dilogLinesB;
    public Dialog dilogLinesC;
    public Dialog dilogLinesD;
    public Dialog dilogLinesE;
    public Dialog dilogLinesF;


    public Dialog dialogLinesSpellVerbal;
    public Dialog dialogLinesInteractives;


    void Start()
    {
        DialogA();
        DialogB();
        DialogC();
        Interactives();
        SpellVerbal();


    }

    // dialag that go back and forth, two chakater converstaion
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
        dilogLinesB.line.Add("I see the crystal raindrops fall\r\nAnd the beauty of it all\r\nIs when the sun comes shining through\r\nTo make those rainbows in my mind\r\nWhen I think of you sometime\r\nAnd I wanna spend some time with you");
        dilogLinesB.line.Add("Just the two of us\r\nWe can make it if we try\r\nJust the two of us\r\n(Just the two of us)\r\nJust the two of us\r\nBuilding castles in the sky\r\nJust the two of us\r\nYou and I");
        dilogLinesB.line.Add("We look for love, no time for tears\r\nWasted water's all that is\r\nAnd it don't make no flowers grow\r\nGood things might come to those who wait\r\nNot for those who wait too late\r\nWe gotta go for all we know");
        dilogLinesB.line.Add("Just the two of us\r\nWe can make it if we try\r\nJust the two of us\r\n(Just the two of us)\r\nJust the two of us\r\nBuilding them castles in the sky\r\nJust the two of us\r\nYou and I");
        dilogLinesB.line.Add("I hear the crystal raindrops fall\r\nOn the window down the hall\r\nAnd it becomes the morning dew\r\nAnd darling when the morning comes\r\nAnd I see the morning sun\r\nI wanna be the one with you");
        dilogLinesB.line.Add("Just the two of us\r\nWe can make it if we try\r\nJust the two of us\r\n(Just the two of us)\r\nJust the two of us\r\nBuilding big castles way on high\r\nJust the two of us\r\nYou and I");
        dilogLinesB.line.Add("7");
        dilogLinesB.line.Add("8");
        dilogLinesB.line.Add("9");
        dilogLinesB.line.Add("10");
    }

    void DialogC()
    {
        dilogLinesC.line.Add("A");
        dilogLinesC.line.Add("B");
        dilogLinesC.line.Add("C");
        dilogLinesC.line.Add("D");
        dilogLinesC.line.Add("E");
        dilogLinesC.line.Add("F");
        dilogLinesC.line.Add("G");
        dilogLinesC.line.Add("H");
        dilogLinesC.line.Add("I");
        dilogLinesC.line.Add("J");
    }

    void Interactives()
    {
        dialogLinesInteractives.line.Add("This place is now of old cosality. The stink of the Yog-agl subtel asail, of evil. The place and time is corrypted. The sorce, the lord, must i find and drag they out of the world and back to the nothing truth of there making");
        dialogLinesInteractives.line.Add("One");
        dialogLinesInteractives.line.Add("Two");
        dialogLinesInteractives.line.Add("Three");
        dialogLinesInteractives.line.Add("Forth");
    }

    void SpellVerbal()
    {
        dialogLinesSpellVerbal.line.Add ("From Erui firstborn woods, through the land of crashing down, come Syls Glare to smite from one hand!");
        dialogLinesSpellVerbal.line.Add("By the arms of Odion, the earth-bound giant, grant me thy Spear, a grueling boon against the Yog-agl!");
        dialogLinesSpellVerbal.line.Add("Glim and see, from land and sea, the With Dwarf Of Circle Valy. Enter through the veil of space and come to light my way!");
        dialogLinesSpellVerbal.line.Add("By The Sacred Order Of I’wacrim. The Good From Inception. Let Moonwater Fall Upon Present Flesh. For Glory Of Their Rest!");
    }
}
