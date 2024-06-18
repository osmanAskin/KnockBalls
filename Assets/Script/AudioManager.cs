using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach (var sound in sounds) 
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    public void Play(SoundType soundType) 
    {
        var s = Array.Find(sounds , sound => sound.type == soundType);
        s.source.Play();
    }
}

public enum SoundType
{
    DefaultBoxBreak,
    GlassBoxBreak,
    GameOver,
    CannonShoot
}

