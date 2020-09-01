using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManEnemy : Enemy
{
    [SerializeField] private float health = 50f;

    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private float moveDirection = 0;
    [SerializeField] private LayerMask detectWhat = 0;
    [SerializeField] private Transform sightTop = null;
    [SerializeField] private Transform sightBot = null;
    [SerializeField] private Animator anim = null;

    enum EnemyStates { Walking, Attacking, Idle, Dead };
    EnemyStates enemyState;
    
    void Start()
    {
        transform.localScale = new Vector2(transform.localScale.x * moveDirection, transform.localScale.y);
        moveSpeed *= moveDirection;
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            enemyState = EnemyStates.Dead;
        }
    }

    public override void EnemyDie()
    {
        anim.SetBool("dead", true);
        Destroy(gameObject, 0.5f);
    }

    public override void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        Debug.Log(health);
    }

    protected override void EnemyWalk()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);

        if (Physics2D.Linecast(sightTop.position, sightBot.position, detectWhat))
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
        }
    }

    protected override void EnemyAttack()
    {
        return;
    }

    protected override void Think()
    {
        enemyState = EnemyStates.Walking;
        CheckHealth();

        switch (enemyState)
        {
            case EnemyStates.Walking:
                //anim.SetBool("isWalking", true);
                anim.SetBool("isDead", false);
                EnemyWalk();
                break;
            case EnemyStates.Dead:
                //anim.SetBool("isWalking", false);
                anim.SetBool("isDead", true);
                StopMovement();
                EnemyDie();
                break;
            default:
                break;
        }
    }
}
