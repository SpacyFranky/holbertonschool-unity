using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Loads the selected level
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
        if (level == 2)
            PlayerPrefs.SetString("PreviousScene", "Level01");
        if (level == 3)
            PlayerPrefs.SetString("PreviousScene", "Level02");
        if (level == 4)
            PlayerPrefs.SetString("PreviousScene", "Level03");
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
        PlayerPrefs.SetString("PreviousScene", "MainMenu");
    }

    // Quits game
    public void QuitGame()
    {
        Debug.Log("Exited");
        Application.Quit ();
    }
}
