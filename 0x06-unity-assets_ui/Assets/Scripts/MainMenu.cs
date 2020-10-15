using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Loads the selected level
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    // Quits game
    public void QuitGame()
    {
        Debug.Log("Exited");
        Application.Quit ();
    }
}
