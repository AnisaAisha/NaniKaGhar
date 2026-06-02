using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Yarn.Unity;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private Sound[] sound;

    private Dictionary<string, AudioClip> soundDict;
    private float musicVolume;
    private float sfxVolume;


    void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        soundDict = new Dictionary<string, AudioClip>();
        foreach (Sound s in sound) soundDict.Add(s.name, s.clip);
    }

    [YarnCommand("audio_sfx")]
    public void PlaySFX(string name, string mode)
    {
        if (mode == "Loop") {
            PlayLoopSoundSFX(name);
        } else if (mode == "Once")
        {
            PlaySingleSoundSFX(name);
        }
    }

    public void PlaySingleSoundSFX(string soundName)
    {
        if (soundDict.TryGetValue(soundName, out var clip))
        {
            SFXSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Song " + soundName + " not found!");
        }
    }

    public void PlayLoopSoundSFX(string soundName)
    {
        if (soundDict.TryGetValue(soundName, out var clip))
        {
            SFXSource.clip = clip;
            SFXSource.loop = true;
            SFXSource.Play();
        }
        else
        {
            Debug.LogWarning("Song " + soundName + " not found!");
        }
    }

    public void StopLoopSoundSFX(string soundName)
    {
        SFXSource.loop = false;
        SFXSource.Stop();
    }

    public void PlayMainMusic(string soundName)
    {
        if (soundDict.TryGetValue(soundName, out var clip))
        {
            if (musicSource.clip == clip && musicSource.isPlaying) return;
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Song " + soundName + " not found!");
        }
    }

    public void SetGlobalVolume(float value)
    {
        musicVolume = value;
        mixer.SetFloat("Volume", Mathf.Log10(value) * 20);
    }

    public void SetGlobalSFX(float value)
    {
        sfxVolume = value;
        mixer.SetFloat("SFX", Mathf.Log10(value) * 20);
    }

    public float GetGlobalVolume() {
        return musicVolume;
    }

    public float GetGlobalSFX() {
        return sfxVolume;
    }
}
