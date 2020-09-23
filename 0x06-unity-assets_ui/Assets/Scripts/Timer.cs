using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        var minutes = time / 60;
        var seconds = time % 60;
        var fraction = (time * 100) % 100;

        timerText.text = string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, fraction);
    }
}
