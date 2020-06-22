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
    [SerializeField] private Vector3 startingPos;

    private void Awake()
    {
        winText.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        //checks if at goal
        if (trigger.gameObject.tag == "Goal")
        {
            movement.enabled = false;
            controller.Move(0, false, false);
            winText.enabled = true;
        }

        //check if respawn
        if (trigger.gameObject.tag == "Boundary")
        {
            this.transform.position = startingPos;
        }

        //check if coin
        if (trigger.gameObject.tag == "Coin")
        {
            trigger.gameObject.SetActive(false);
            scoreText.text = (Convert.ToInt32(scoreText.text) + 100).ToString();
            Debug.Log("Score Increased");
        }
    }
}
