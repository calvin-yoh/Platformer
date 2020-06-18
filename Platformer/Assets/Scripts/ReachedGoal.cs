using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ReachedGoal : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private PlayerMovement movement;


    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            text.enabled = true;
            movement.SetSpeed(0);
        }
    }
}

