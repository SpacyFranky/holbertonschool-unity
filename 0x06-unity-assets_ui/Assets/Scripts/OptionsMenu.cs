using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{   
    public Toggle yAxis;

    public void Start()
    {
        bool toggled = PlayerPrefs.GetInt("IsInverted") == 1 ? true : false;
        yAxis.isOn = toggled;
    }
    
    // Loads the previous scene
    public void Back()
    {
        string scene = PlayerPrefs.GetString("PreviousScene");
        SceneManager.LoadScene(scene);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    // Applies options
    public void Apply()
    {
        if (!yAxis.isOn)
            PlayerPrefs.SetInt("IsInverted", 0);
        else
            PlayerPrefs.SetInt("IsInverted", 1);
        Back();
    }
}
