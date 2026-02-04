using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public float volume;
    public bool loop;
    public AudioSource source;
}
