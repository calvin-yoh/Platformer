using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] private CharacterController2D controller;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private Text winText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;
    [SerializeField] private Vector3 startingPos;
    [SerializeField] private float currLives = 3;
    
    private LayerMask detectEnemy;
    

    private void Awake()
    {
        winText.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Goal") //checks if at goal
        {
            movement.enabled = false;
            controller.Move(0, false, false);
            winText.enabled = true;
        }
        else if (trigger.gameObject.tag == "Boundary") // check if respawn
        {
            PlayerDie();
        }
        else if (trigger.gameObject.tag == "Coin") //check if coin
        {
            scoreText.text = (Convert.ToInt32(scoreText.text) + 100).ToString();
        }
        else if (trigger.gameObject.tag == "Enemy")
        {
            scoreText.text = (Convert.ToInt32(scoreText.text) + 100).ToString();
        }
    }

    public void PlayerDie()
    {
        this.transform.position = startingPos;
        currLives -= 1;
        livesText.text = "Lives : " + currLives.ToString();
    }

    public void AddLife()
    {
        currLives += 1;
    }
}
