using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource running;
    AudioSource falling;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        running = sources[0];
        falling = sources[1];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayerFootstepSound()
    {
        running.Play();
    }

    private void PlayerFallingImpactSound()
    {
        falling.Play();
    }
}
