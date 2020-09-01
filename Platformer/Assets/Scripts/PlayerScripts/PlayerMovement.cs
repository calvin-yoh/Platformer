using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//わたしのともだちはばかです。

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller = null;

    [SerializeField] private Animator anim = null;

    [SerializeField] private float runSpeed = 40f;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        anim.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("isJumping", true);
            Debug.Log("gotButton");
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
        if (knockbackCount <= 0)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        }
        else
        {
            if (knockFromRight)
            {
                controller.PlayerKnockback(-knockback, knockback);
            }
            if (!knockFromRight)
            {
                controller.PlayerKnockback(knockback, knockback);
            }
            knockbackCount -= Time.deltaTime;
        }
        jump = false;
    }

    public void OnLanding()
    {
        Debug.Log("landed");
        anim.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        anim.SetBool("isCrouching", isCrouching);
    }
}
