using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip bgmMap;

    public AudioClip walkSfx;

    public AudioClip cashSfx;

    public AudioClip normalBtnSfx;

    public AudioSource bgmAudioSource;

    public AudioSource sfxAudioSource;

    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;

        PlayBgm(bgmMap);
    }

    /// <summary>
    /// Function to play a bgm in this game
    /// </summary>
    /// <param name="clip"></param>
    public void PlayBgm(AudioClip clip)
    {
        if (clip == null || bgmAudioSource == null)
            return;

        bgmAudioSource.clip = clip;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }

    /// <summary>
    /// Function to play sfx in this game
    /// </summary>
    /// <param name="sfx"></param>
    public void PlaySfx(AudioClip sfx)
    {
        if (sfx == null || sfxAudioSource == null)
            return;
        sfxAudioSource.PlayOneShot(sfx);
    }
}
