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
        else if (collider.gameObject.tag == "Weapon")
        {
            manager.SetWeapon(collider.gameObject.GetComponent<Weapon>());
            manager.OverrideAnimationController();
            collider.gameObject.SetActive(false);
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
    }
}
