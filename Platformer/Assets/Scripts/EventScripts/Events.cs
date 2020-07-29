using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static event Action<int> OnUpdateScore;
    public static event Action<int> OnUpdateLives;
    public static event Action<int> OnUpdateHealthBar;
    public static event Action OnShowWinScreen;


    public static event Action<AudioClip> OnPlaySound;

    public static void RaiseUpdateScoreEvent(int newScore) => OnUpdateScore?.Invoke(newScore);
    public static void RaiseUpdateLivesEvent(int newLives) => OnUpdateScore?.Invoke(newLives);
    public static void RaiseUpdateHealthBarEvent(int newHealth) => OnUpdateHealthBar?.Invoke(newHealth);
    public static void RaiseShowWinScreenEvent() => OnShowWinScreen?.Invoke();


    public static void RaisePlaySoundEvent(AudioClip soundToPlay) => OnPlaySound?.Invoke(soundToPlay);
}
