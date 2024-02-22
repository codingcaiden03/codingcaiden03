using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] float volume;
    [SerializeField] AudioClip bounceSFX;
    [SerializeField] AudioClip scoreSFX;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBounceSFX()
    {
        audioSource.PlayOneShot(bounceSFX, volume);
    }

    public void PlayScoreSFX()
    {
        audioSource.PlayOneShot(scoreSFX, volume);
    }
}