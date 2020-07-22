using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller = null;
    [SerializeField] private PlayerMovement movement = null;
    [SerializeField] private PlayerManager manager = null;

    [SerializeField] private Animator anim = null;

    private LayerMask detectEnemy;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Goal") //checks if at goal
        {
            manager.DisableMovementCompletely();
            manager.ShowWinScreen();
        }
        else if (collider.gameObject.tag == "Enemy")
        {
            manager.TakeDamage(10f);
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Boundary") // check if respawn
        {
            manager.PlayerDie();
        }
        else if (trigger.gameObject.tag == "Coin") //check if coin
        {
            manager.UpdateScore(100);
        }
        else if (trigger.gameObject.tag == "Weapon")
        {           
            manager.SetWeapon(trigger.GetComponent<Weapon>());
            manager.OverrideAnimationController();
            trigger.gameObject.SetActive(false);
        }
    }
}
