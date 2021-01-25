using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float time;
    private Vector3 startingPoint;
    public Text finalTimeText;

    public void Start()
    {
        startingPoint = transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        if (transform.position != startingPoint)
            time += Time.deltaTime;

        var minutes = time / 60;
        var seconds = time % 60;
        var fraction = (time * 100) % 100;

        timerText.text = string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, fraction);

        if (Time.timeScale == 0)
            Win();
    }

    // Shows the finish time
    public void Win()
    {
        finalTimeText.text = timerText.text;
    }
}
