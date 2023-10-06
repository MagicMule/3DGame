using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogText : MonoBehaviour
{
    [System.Serializable]
    public class Dialog1
    {
        public List<string> line;
    }

    public Dialog1 dilogLinesA;


    void Start()
    {

        dilogLinesA.line.Add("1");
        dilogLinesA.line.Add("2");
        dilogLinesA.line.Add("3");
        dilogLinesA.line.Add("4");
        dilogLinesA.line.Add("5");
        dilogLinesA.line.Add("6");
        dilogLinesA.line.Add("7");
        dilogLinesA.line.Add("8");
        dilogLinesA.line.Add("9");
        dilogLinesA.line.Add("10");


    }


    void Update()
    {
        
    }

}
