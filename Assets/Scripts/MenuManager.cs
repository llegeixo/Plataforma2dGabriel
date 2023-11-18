using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Platforms");
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lose");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
