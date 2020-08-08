using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text winText = null;
    [SerializeField] private Text livesText = null;
    [SerializeField] private Text scoreText = null;

    private void Awake()
    {

    }

    private void OnEnable()     // subscribe event
    {
        Events.OnUpdateScore += UpdateScore;
        Events.OnUpdateLives += UpdateLives;
        Events.OnShowWinScreen += ShowWinText;
        Events.OnUpdateHealthBar += UpdateHealthBar;
    }

    private void OnDisable()    // unsubscribe event
    {
        Events.OnUpdateScore -= UpdateScore;
    }

    private void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

    private void UpdateLives(int newLives)
    {
        livesText.text = newLives.ToString();
    }

    private void ShowWinText()
    {
        winText.enabled = true;
    }

    private void UpdateHealthBar(int newHealth)
    { 
        
    }
}
