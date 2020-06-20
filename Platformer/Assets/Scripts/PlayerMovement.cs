using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//わたしのともだちはばかです。

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private float runSpeed = 40f;
    [SerializeField] private Text winText;
    [SerializeField] private Vector3 startingPos;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;


    private void Awake()
    {
        winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void OnTriggerEnter2D(Collider2D trigger)
    { 
        //checks if at goal
        if (trigger.gameObject.tag == "Goal")
        {
            horizontalMove = 0;
            controller.Move(0, false, false);
            winText.enabled = true;
            this.enabled = false;
        }

        //check if respawn
        if (trigger.gameObject.tag == "Boundary")
        {
            this.transform.position = startingPos;
        }
    }
}