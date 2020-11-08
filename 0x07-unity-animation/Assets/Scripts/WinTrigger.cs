using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public Text timerText;
    public GameObject winCanvas;


    void OnTriggerEnter(Collider other)
    {
        /*timerText.color = new Color(0, 255, 0);
        timerText.fontSize = 90;*/
        timerText.enabled = false;
        winCanvas.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
