using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, deathSound, backgroundSound, bonusSound, colorChanger;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Whoosh");
        deathSound = Resources.Load<AudioClip>("Bonus");
        bonusSound = Resources.Load<AudioClip>("Bonus");
        colorChanger = Resources.Load<AudioClip>("ButtonPress");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Whoosh":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "GruntVoice02":
                audioSrc.PlayOneShot(deathSound);
                break;
            case "Bonus":
                    audioSrc.PlayOneShot(bonusSound);
                break;
            case "ButtonPress":
                audioSrc.PlayOneShot(colorChanger);
                break;
        }
    }
}
