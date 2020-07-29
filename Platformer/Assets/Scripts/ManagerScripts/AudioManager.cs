using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        // Subscribe to the event. When the event gets raised, PlayClip will be executed
        Events.OnPlaySound += PlayClip;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event to remove it from the listener pool
        Events.OnPlaySound -= PlayClip;
    }

    private void PlayClip(AudioClip clipToPlay)
    {
        source.clip = clipToPlay;
        source.Play();
    }
}
