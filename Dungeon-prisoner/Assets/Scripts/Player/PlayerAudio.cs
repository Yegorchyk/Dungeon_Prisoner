using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audio;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void StepVolume(AudioClip step1)
    {
        audio.volume = 0.5f;
        audio.PlayOneShot(step1);
    }

    public AudioClip hit;
    public void HitSound(float volume)
    {
        audio.volume = volume;
        audio.PlayOneShot(hit);
    }
}
