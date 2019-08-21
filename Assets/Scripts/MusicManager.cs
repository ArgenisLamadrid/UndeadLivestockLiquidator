using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public static AudioClip BackgroundMusic;
    static AudioSource musicSrc;

    // Use this for initialization
    void Start()
    {
        BackgroundMusic = Resources.Load<AudioClip>("BackgroundMusic");
        musicSrc = GetComponent<AudioSource>();
    }


    void FixedUpdate () 
    {
        if (!musicSrc.isPlaying)
        {
            musicSrc.PlayOneShot(BackgroundMusic);
        }
    }
}
