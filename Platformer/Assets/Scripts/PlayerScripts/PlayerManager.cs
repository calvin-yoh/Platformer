using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Animator anim = null;
    [SerializeField] private AnimatorOverrideController animatorOverrideController = null;

    //[SerializeField] private Text winText = null;
    //[SerializeField] private Text scoreText = null;
    //[SerializeField] private Text livesText = null;
    [SerializeField] private Vector3 startingPos;

    [SerializeField] private float health = 100f;
    [SerializeField] private float currLives = 3;

    private PlayerMovement playerMovement = null;
    private PlayerInteraction playerInteract = null;
    private PlayerAttack playerAttack = null;
    private CharacterController2D controller = null;

    private Weapon currWeapon = null;
    
    private void Awake()
    {
    
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerInteract = GetComponent<PlayerInteraction>();
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currWeapon)
        {
            playerAttack.CheckAttack(currWeapon);           
        }
    }

    public void OverrideAnimationController()
    {
        anim.runtimeAnimatorController = animatorOverrideController;
        animatorOverrideController["PlayerDummyAttack"] = currWeapon.GetAttackAnimClip();
        animatorOverrideController["PlayerIdle"] = currWeapon.GetIdleAnimClip();
        Debug.Log("overrode");
    }

    public void SetWeapon(Weapon typeCollected)
    {
        currWeapon = typeCollected.GetWeaponType();
    }

    public void AddLife()
    {
        currLives += 1;
        UpdateLives(currLives);
    }

    public void PlayerDie()
    {
        this.transform.position = startingPos;
        currLives -= 1;
        UpdateLives(currLives);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Events.RaiseUpdateHealthBarEvent(health);
    }

    public void DisableMovementCompletely()
    {
        playerMovement.enabled = false;
        controller.Move(0, false, false);
        anim.SetFloat("speed", 0);
    }

    public void ShowWinScreen() => Events.RaiseShowWinScreenEvent();

    public void UpdateScore(float points) => Events.RaiseUpdateScoreEvent(points);

    public void UpdateLives(float currLives) => Events.RaiseUpdateScoreEvent(currLives);
}
