using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] musicClips;

    AudioSource audioSource;
    int excludeMusic;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        int randMusic = Random.Range(0, musicClips.Length);
        if (randMusic == excludeMusic) return;
        audioSource.clip = musicClips[randMusic];
        excludeMusic = randMusic;
        audioSource.Play();
    }

    private void FixedUpdate()
    {
        if (!audioSource.isPlaying)
        {
            Start();
        }
    }
}
