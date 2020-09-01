using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static event Action<float> OnUpdateScore;
    public static event Action<float> OnUpdateLives;
    public static event Action<float> OnUpdateHealthBar;
    public static event Action OnShowWinScreen;


    public static event Action<AudioClip> OnPlaySound;

    public static void RaiseUpdateScoreEvent(float newScore) => OnUpdateScore?.Invoke(newScore);
    public static void RaiseUpdateLivesEvent(float newLives) => OnUpdateScore?.Invoke(newLives);
    public static void RaiseUpdateHealthBarEvent(float newHealth) => OnUpdateHealthBar?.Invoke(newHealth);
    public static void RaiseShowWinScreenEvent() => OnShowWinScreen?.Invoke();


    public static void RaisePlaySoundEvent(AudioClip soundToPlay) => OnPlaySound?.Invoke(soundToPlay);
}
