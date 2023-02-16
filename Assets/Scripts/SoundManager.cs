using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGMType
{
    None,
    Title,
    InGame,
    InBoss,
}

public enum SEType
{
    GameClear,
    GameOver,
    Shoot,
}
public class SoundManager : MonoBehaviour
{
    public AudioClip bgmInTitle;
    public AudioClip bgmInGame;
    public AudioClip bgmInBoss;

    public AudioClip seGameClear;
    public AudioClip seGameOver;
    public AudioClip seShoot;

    public BGMType playingBGM = BGMType.None;


    public static SoundManager soundManager = null;
    
    private void Awake()
    {
        if (soundManager == null)
        {
            soundManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGMType type)
    {
        if (type != playingBGM)
        {
            playingBGM = type;
            AudioSource audio = GetComponent<AudioSource>();
            if (type == BGMType.InGame)
            {
                audio.clip = bgmInGame;
            }

            audio.Play();
        }
    }

    public void StopBGM()
    {
        GetComponent<AudioSource>().Stop();
        playingBGM = BGMType.None;
    }

    public void SEPlay(SEType type)
    {
        if (type == SEType.Shoot)
        {
            GetComponent<AudioSource>().PlayOneShot(seShoot);
        }
    }
}
