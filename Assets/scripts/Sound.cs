using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip audio;
    public float volume;
    public bool isLoop;
    public AudioSource audioSource;
}
