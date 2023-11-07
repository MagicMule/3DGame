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
        dilogLinesB.line.Add("...");
        dilogLinesB.line.Add("...");
        dilogLinesB.line.Add("Withround. I was brealey of the threould of this cursed place, and in the darkness I called you and you gave no answer.");
        dilogLinesB.line.Add("...I got lost...");
        dilogLinesB.line.Add("You got lost because you wandered! We have an agreement, you are to stay at my side and answer when I call. Are you to shame your character?");
        dilogLinesB.line.Add("… I'm sorry. But I'm excited! It's been some time since I was in such a place! My nature is to wander, how could one not when such adventure, such mystery is afoot!");
        dilogLinesB.line.Add("Considering you have wandered. What do you make of what you have seen?");
        dilogLinesB.line.Add("I'm no sage such as you, but this place is significant. This must indeed be the deen of the Demon. We are indeed in the material but this place is sudo-material. I doubt the creed stands firmly here. The corridors and chambers will not be stacanary and even more so further in we go.");
        dilogLinesB.line.Add("Let's continue. You're not the only spell to go astray.");
        dilogLinesB.line.Add("Lets go! O Wait. Allsow, there are others here.");
        dilogLinesB.line.Add("Indeed, I saw the remains of a camp on my way here. Now come.");
        dilogLinesB.line.Add("Aye, Aye!");
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
        dialogLinesInteractives.line.Add("Pages corroded, scared thou time. But  from what is latigable it seems to be the remanence of an index of the library's stock. From A-Ö in subject and A-Ö in title.");
        dialogLinesInteractives.line.Add("Locked. A place in a place of itself. A restricted access to, presumably, more obscure unvented knowledge. Miscaractasitons, falsehood, or perceived such, of nature and character. And two; valuable, irreplaceable things of arcana and esoterica.");
        dialogLinesInteractives.line.Add("Locked. A place in a place of itself. A restricted access to, presumably, more obscure unvented knowledge. Miscaractasitons, falsehood, or perceived such, of nature and character. And two; valuable, irreplaceable things of arcana and esoterica.");
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
