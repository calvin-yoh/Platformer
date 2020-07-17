using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] private CharacterController2D controller = null;
    [SerializeField] private PlayerMovement movement = null;
    [SerializeField] private Animator anim = null;
    [SerializeField] private Text winText = null;
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text livesText = null;
    [SerializeField] private Vector3 startingPos;
    [SerializeField] private float currLives = 3;
    
    private LayerMask detectEnemy;
    

    private void Awake()
    {
        winText.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Goal") //checks if at goal
        {
            movement.enabled = false;
            controller.Move(0, false, false);
            winText.enabled = true;
            anim.SetFloat("speed", 0);
        }
        else if (collider.gameObject.tag == "Enemy")
        {
            PlayerDie();
            //scoreText.text = (Convert.ToInt32(scoreText.text) + 100).ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Boundary") // check if respawn
        {
            PlayerDie();
        }
        else if (trigger.gameObject.tag == "Coin") //check if coin
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
