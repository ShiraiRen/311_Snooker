using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Startgame()
    {
        SceneManager.LoadScene("Scaen01");
    }

    public void Exit()
    {
        Application.Quit();
    }
}