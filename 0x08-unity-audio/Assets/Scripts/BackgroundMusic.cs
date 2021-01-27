using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource bgMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        bgMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        bgMusic.Stop();
    }
}
