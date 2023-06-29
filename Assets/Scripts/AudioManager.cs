using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource levelMusic, gameOverMusic, winMusic, completedMusic, startMusic;
    public AudioSource[] sfx;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGameOver()
    {
        levelMusic.Stop();
        gameOverMusic.Play();
    }
    public void PlayWinMusic()
    {
        levelMusic.Stop();
        winMusic.Play();
    }
    public void PLaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }
    public void PlayCompletedMusic()
    {
        levelMusic.Stop();
        completedMusic.Play();
    }
    public void PlayStartMusic()
    {
        startMusic.Play();
    }
}
