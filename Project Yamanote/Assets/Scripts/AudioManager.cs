using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.outputAudioMixerGroup;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    public IEnumerator FadeOut(string name, float FadeTime)
    {
        Sound s = Array.Find(instance.sounds, sound => sound.name == name);
        float startVolume = s.volume;

        while (s.volume > 0)
        {
            s.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        s.source.Stop();
        s.volume = startVolume;
    }

    public IEnumerator FadeIn(string name, float FadeTime)
    {
        Sound s = Array.Find(instance.sounds, sound => sound.name == name);
        float startVolume = 0.2f;

        s.volume = 0;
        s.source.Play();

        while (s.volume < 1.0f)
        {
            s.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        s.volume = 1f;
    }
}
