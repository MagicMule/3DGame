using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInterations : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGameButton()
    {
        Application.Quit();
    }
}
