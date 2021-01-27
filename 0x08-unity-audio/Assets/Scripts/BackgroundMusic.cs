using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource[] bgAudio;
    AudioSource bgMusic;
    AudioSource victoryPiano;
    
    // Start is called before the first frame update
    void Start()
    {
        bgAudio = GetComponents<AudioSource>();
        bgMusic = bgAudio[0];
        victoryPiano = bgAudio[1];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        bgMusic.Stop();
        victoryPiano.Play();
    }
}
