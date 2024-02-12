using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInterations : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitGameButton()
    {
        //
    }
}
