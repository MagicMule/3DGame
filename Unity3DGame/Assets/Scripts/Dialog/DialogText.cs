using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogText : MonoBehaviour
{
    [System.Serializable]
    public class DialogueData
    {
        public List<string> lines;
    }

    [Header("Dialog Lines")]
    public DialogueData dialogLinesA;
    public DialogueData dialogLinesB;
    public DialogueData dialogLinesC;
    public DialogueData dialogLinesD;
    public DialogueData dialogLinesE;
    public DialogueData dialogLinesF;

    public DialogueData dialogLinesSpellVerbal;
    public DialogueData dialogLinesInteractives;


    void Start()
    {
        DialogA();
        DialogB();
        DialogC();
        DialogC1();
        DialogC2();
        DialogC3();
        Interactives();
        SpellVerbal();


    }

    // dialag that go back and forth, two chakater converstaion
    void DialogA()
    {
        dialogLinesA.lines.Add("...");
        dialogLinesA.lines.Add("How are you feeling?");
        dialogLinesA.lines.Add("How should I feel? I'm as I have been. Don't worry, Im am but ready");
        dialogLinesA.lines.Add("Truly? I have not made that demand of you, only ask if you are willing. You have experience, friends and knowledge and power. But you will dwell in a place where flesh and blood is law.");
        dialogLinesA.lines.Add("Indeed. I have my contacts. Some are in me now and will follow me to Arums shores, others linger behind the moon and in the gleam of the stars. They will serve me as I have served them, by law.");
        dialogLinesA.lines.Add("Laws, is it? Arum is a land where people make their own law. Are you sure a sneak will not cross and deny you?");
        dialogLinesA.lines.Add("No, but that is the why of things. If in truth I have but my will and a drop of blood, it will have to do");
        dialogLinesA.lines.Add("Not to worry, I have some to give you. The tip of the spear were forged in the Diamond Spring. It is the arm against the Yog-agl. You already know its name.");
    }

    void DialogB()
    {
        dialogLinesB.lines.Add("...");
        dialogLinesB.lines.Add("...");
        dialogLinesB.lines.Add("Withround. I was brealey of the threould of this cursed place, and in the darkness I called you and you gave no answer.");
        dialogLinesB.lines.Add("...I got lost...");
        dialogLinesB.lines.Add("You got lost because you wandered! We have an agreement, you are to stay at my side and answer when I call. Are you to shame your character?");
        dialogLinesB.lines.Add("… I'm sorry. But I'm excited! It's been some time since I was in such a place! My nature is to wander, how could one not when such adventure, such mystery is afoot!");
        dialogLinesB.lines.Add("Considering you have wandered. What do you make of what you have seen?");
        dialogLinesB.lines.Add("I'm no sage such as you, but this place is significant. This must indeed be the deen of the Demon. We are indeed in the material but this place is sudo-material. I doubt the creed stands firmly here. The corridors and chambers will not be stacanary and even more so further in we go.");
        dialogLinesB.lines.Add("Let's continue. You're not the only spell to go astray.");
        dialogLinesB.lines.Add("Lets go! O Wait. Allsow, there are others here.");
        dialogLinesB.lines.Add("Indeed, I saw the remains of a camp on my way here. Now come.");
        dialogLinesB.lines.Add("Aye, Aye!");
    }

    void DialogC()
    {
        dialogLinesC.lines.Add("Hello");
        dialogLinesC.lines.Add("AAAh! Ow. Greetings to you. I was absorbed in my material. Are you true? Who are you?");
        dialogLinesC.lines.Add("I’m here for the disturbance that has become nature here, to rout it out. I'm also searching for some spells that went astray.");
        dialogLinesC.lines.Add("Spells astray? Well this is indeed the place to come then. These halls are a treasure beyond, the potential is intoxicating. Uninterpretable things on the surface will be the soft butter and this library the hot blade. But maybe that is already so for you?");
        dialogLinesC.lines.Add("It is not.");
        dialogLinesC.lines.Add("But I'm sure there is much to learn from you, my friend. Maybe we can come to an accord?");
        dialogLinesC.lines.Add("You have something to offer me?");
        dialogLinesC.lines.Add("I have a key to the barred restricted section of the library. If you were to find a spell, this is where it must have wandered, as they tend to do. I have not made the way myself, active guardians are in the path. And do not try anything funny! The key is hidden for now.");
        dialogLinesC.lines.Add("What would you have of me?");
        dialogLinesC.lines.Add("In this library there is a room housing a mystical inscribed circle on the ground. I believe this could be a portal, a ritual to walk the astral plane. But I do not have the spell or power to make it function. I need the hand of a dead god and so I would like to make the journey. Would you make it in my stead?");
        dialogLinesC.lines.Add("You ask a lot but it may be possible.");
        dialogLinesC.lines.Add("And give me the name of the Moon-Man!");
        dialogLinesC.lines.Add(" … You are being absurd. I can give you one of the names of the three kings of the 2001th Moon.");
        dialogLinesC.lines.Add("Two kings!");
        dialogLinesC.lines.Add("No.");
        dialogLinesC.lines.Add("Deal!");
        dialogLinesC.lines.Add("I will return shortly. Hopefully.");

    }
    
    void DialogC1()
    {

    }
    
    void DialogC2()
    {

    }
    void DialogC3()
    {

    }


    void Interactives()
    {
        dialogLinesInteractives.lines.Add("This place is now of old cosality. The stink of the Yog-agl subtel asail, of evil. The place and time is corrypted. The sorce, the lord, must i find and drag they out of the world and back to the nothing truth of there making");
        dialogLinesInteractives.lines.Add("Pages corroded, scared thou time. But  from what is latigable it seems to be the remanence of an index of the library's stock. From A-Ö in subject and A-Ö in title.");
        dialogLinesInteractives.lines.Add("Locked. A place in a place of itself. A restricted access to, presumably, more obscure unvented knowledge. Miscaractasitons, falsehood, or perceived such, of nature and character. And two; valuable, irreplaceable things of arcana and esoterica.");
        dialogLinesInteractives.lines.Add("A wall have materialised behind the door. I can not make it back this why");
        dialogLinesInteractives.lines.Add("Rubel and pillar blocks my way. It is big but brittle. If struck by a grand force, like spell of the like Odion’s Spear, it may clear a path.");
    }

    void SpellVerbal()
    {
        dialogLinesSpellVerbal.lines.Add ("From Erui firstborn woods, through the land of crashing down, come Syls Glare to smite from one hand!");
        dialogLinesSpellVerbal.lines.Add("By the arms of Odion, the earth-bound giant, grant me thy Spear, a grueling boon against the Yog-agl!");
        dialogLinesSpellVerbal.lines.Add("Glim and see, from land and sea, the With Dwarf Of Circle Valy. Enter through the veil of space and come to light my way!");
        dialogLinesSpellVerbal.lines.Add("By The Sacred Order Of I’wacrim. The Good From Inception. Let Moonwater Fall Upon Present Flesh. For Glory Of Their Rest!");
    }
}
