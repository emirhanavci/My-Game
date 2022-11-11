using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    [SerializeField]
    private AudioClip boost, star, bomb, bgMusic;
    [SerializeField]
    private AudioSource soundFX, bgMusicSource;

    // Use this for initialization
    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void PlayStar()
    {
        soundFX.PlayOneShot(star);
    }

    public void PlayBoost()
    {
        soundFX.PlayOneShot(boost);
    }
    public void PlayBomb()
    {
        soundFX.PlayOneShot(bomb);
    }
    public void PlayMusic()
    {
        bgMusicSource.Play();
    }

}