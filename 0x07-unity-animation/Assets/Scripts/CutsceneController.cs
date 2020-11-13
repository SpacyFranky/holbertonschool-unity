using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    private Animator anim;
    public GameObject mainCamera;
    public GameObject cutsceneCamera;
    public GameObject player;
    public GameObject timerCanvas;

    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isAnimationStatePlaying(anim, 0, "Intro01") == true && Input.GetKeyDown("space"))
        {
            player.GetComponent<PlayerController>().enabled = true;
            mainCamera.SetActive(true);
            timerCanvas.SetActive(true);
            cutsceneCamera.SetActive(false);
        }
        
        if (isAnimationStatePlaying(anim, 0, "Intro01") == false)
        {
            player.GetComponent<PlayerController>().enabled = true;
            mainCamera.SetActive(true);
            timerCanvas.SetActive(true);
            cutsceneCamera.SetActive(false);
        }
    }


    bool isAnimationStatePlaying(Animator anim, int animLayer, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
            anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}
