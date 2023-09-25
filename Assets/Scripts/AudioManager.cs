using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    public GameObject Player;
    public AudioSource[] soundEffects;
    public AudioSource bgm, levelClearMusic;
 
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySXF(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();
        soundEffects[soundToPlay].pitch = Random.Range(0.9f, 1.1f);
        soundEffects[soundToPlay].Play();
    }
    
    public void BgmStop()
    {
        bgm.Stop();
    }

    public void win()
    {
        levelClearMusic.Play();
    }
}
