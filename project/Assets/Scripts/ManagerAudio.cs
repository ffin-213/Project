using System;
using UnityEngine;

public class ManagerAudio : MonoBehaviour
{
    public static ManagerAudio Instance;

    public AudioClip[] musicSounds, sfxSounds, masterSounds;
    public AudioSource musicSource, sfxSource, masterSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        AudioClip s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.LogWarning("Music Sound Not Found: " + name);
        }
        else
        {
            musicSource.clip = s;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        AudioClip s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.LogWarning("SFX Sound Not Found: " + name);
        }
        else
        {
            sfxSource.PlayOneShot(s);
        }
    }

    public void PlayMaster(string name)
    {
        AudioClip s = Array.Find(masterSounds, x => x.name == name);

        if (s == null)
        {
            Debug.LogWarning("Master Sound Not Found: " + name);
        }
        else
        {
            masterSource.PlayOneShot(s);
        }
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void ToggleMaster()
    {
        masterSource.mute = !masterSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
    public void MasterVolume(float volume)
    {
        masterSource.volume = volume;
    }
}
