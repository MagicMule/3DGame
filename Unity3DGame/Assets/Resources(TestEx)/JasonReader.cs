using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JasonReader : MonoBehaviour
{

    /// <summary>
    /// read form a JSON file
    /// </summary>

    public TextAsset textJSON;

    [System.Serializable]
    public class Player
    {
        public string line1;
        public string line2;
    }

    [System.Serializable]

    public class PlayerList
    {
        public Player[] dialogScene1;
    }

    public PlayerList myPlayerList = new PlayerList();



    // Start is called before the first frame update
    void Start()
    {
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);

        Debug.Log(myPlayerList.dialogScene1[1].line1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
