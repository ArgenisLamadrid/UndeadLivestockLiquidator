using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{


    public static AudioClip ShootSound, DamageSound, ChickenDeath, CowDeath, PigDeath, DuckDeath, CharacterDeath;
    static AudioSource soundSrc;

    // Use this for initialization
    void Start()
    {

        ShootSound = Resources.Load<AudioClip>("GunShot");
        DamageSound = Resources.Load<AudioClip>("Damage_01");
        ChickenDeath = Resources.Load<AudioClip>("ChickenDeath");
        CowDeath = Resources.Load<AudioClip>("CowDeath");
        PigDeath = Resources.Load<AudioClip>("PigDeath");
        DuckDeath = Resources.Load<AudioClip>("DuckDeath");
        CharacterDeath = Resources.Load<AudioClip>("CharacterDeath");

        soundSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Play(string clip)
    {
        switch (clip)
        {
            case "ShootSound":
                soundSrc.PlayOneShot(ShootSound);
                break;
            case "DamageSound":
                soundSrc.PlayOneShot(DamageSound);
                break;
            case "ChickenDeath":
                soundSrc.PlayOneShot(ChickenDeath);
                break;
            case "CowDeath":
                soundSrc.PlayOneShot(CowDeath);
                break;
            case "PigDeath":
                soundSrc.PlayOneShot(PigDeath);
                break;
            case "DuckDeath":
                soundSrc.PlayOneShot(DuckDeath);
                break;
            case "CharacterDeath":
                soundSrc.PlayOneShot(CharacterDeath);
                break;
        }
    }
}