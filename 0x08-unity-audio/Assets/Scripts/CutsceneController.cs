using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    private Animator anim;
    public GameObject mainCamera;
    public GameObject cutsceneCamera;
    public GameObject player;
    public GameObject timerCanvas;
    private string scene;
    private string animNb;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        scene = SceneManager.GetActiveScene().name;
        animNb = scene.Replace("Level", "Intro");
    }

    void Update()
    {
        if (isAnimationStatePlaying(anim, 0, animNb) == true && Input.GetKeyDown("return"))
        {
            player.GetComponent<PlayerController>().enabled = true;
            mainCamera.SetActive(true);
            timerCanvas.SetActive(true);
            cutsceneCamera.SetActive(false);
        }
        
        if (isAnimationStatePlaying(anim, 0, animNb) == false)
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
