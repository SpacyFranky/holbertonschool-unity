using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    // Public variable to store the PlayButton UI gameobject
    public Button play;
    // Public variable to store the QuitButton UI gameobject
    public Button quit;

    // Public variable to store trap material
    public Material trapMat;
    // Public variable to store goal material
    public Material goalMat;
    // Public variable to store ColorblindMode UI gameobject
    public Toggle colorblindMode;

    void Start()
    {
        PlayMaze();
        QuitMaze();
    }
    
    // loads the maze scene when the Play button is pressed
    public void PlayMaze()
    {
        play.onClick.AddListener(PlayOnClick);
    }

    // Closes the game window when the Quit button is pressed
    public void QuitMaze()
    {
        quit.onClick.AddListener(QuitOnClick);
    }

    public void PlayOnClick()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = new Color32(255, 0, 0, 1);
            goalMat.color = new Color32(0, 255, 0, 255);
        }
        SceneManager.LoadScene("maze");
    }

    public void QuitOnClick()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
