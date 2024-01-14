using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] _sounds;
    public AudioMixer _audioMixer;
    public AudioMixerGroup _audioMixerGroup;
    public Slider _volumeSlider;
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            ChangeVolume();
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
            sound.source.outputAudioMixerGroup = _audioMixerGroup;
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

    public void ChangeVolume()
    {
        _audioMixer.SetFloat("masterVolume", Mathf.Log10(_volumeSlider.value) * 20);
    }
}
