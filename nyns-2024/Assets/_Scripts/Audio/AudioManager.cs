using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] _sounds;
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound sound in _sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
        }
    }

    void Start()
    {
        Play("First Impression");
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(_sounds, sound => sound.name == name);

        if(sound != null)
        {
            sound.source.Play();
        }
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(_sounds, sound => sound.name == name);

        if(sound != null)
        {
            sound.source.Stop();
        }
    }
}
