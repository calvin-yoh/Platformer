using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggoEnemy : Enemy
{
    [SerializeField] private float health = 50f;
    [SerializeField] private float damageToDeal = 10f;

    [SerializeField] private float moveSpeed = 0;
    [SerializeField] private float moveDirection = 0;
    [SerializeField] private LayerMask detectWhat = 0;
    [SerializeField] private Transform sightTop = null;
    [SerializeField] private Transform sightBot = null;
    [SerializeField] private Animator anim = null;

    private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack = 0f;
    [SerializeField] private float forceMultiplier = 0f;

    [SerializeField] private Transform attackOrigin;
    [SerializeField] private Transform originOfExplode;
    [SerializeField] private LayerMask lookForPlayer;
    [SerializeField] private float attackRange;

    private float timeSpentAttacking = 0.77f;
    private float tempTimeSpentAttacking = 0.77f;
    private float timeSpentIdle = 1f;
    private float tempTimeSpentIdle = 1f;

    enum EnemyStates { Walking, Attacking, Idle, Dead};
    EnemyStates enemyState;

    void Start()
    {
        transform.localScale = new Vector2(transform.localScale.x * moveDirection, transform.localScale.y);
        moveSpeed *= moveDirection;
    }

    private void FixedUpdate()
    {
        anim.SetBool("isHit", false);
    }

    public override void TakeDamage(float damageTaken)
    {
        anim.SetBool("isHit", true);
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
        Collider2D col = Physics2D.OverlapCircle(attackOrigin.position, attackRange, lookForPlayer);
        if (col != null)
        {
            col.GetComponent<PlayerManager>().TakeDamage(damageToDeal);
            KnockbackPlayer(col.gameObject);
        }
    }

    public override void EnemyDie()
    {
        Destroy(gameObject, 0.66f);
    }

    protected override void ActivateHitAnim()
    {
        anim.SetBool("isHit", true);
    }

    protected override void DeactivateHitAnim()
    {
        anim.SetBool("isHit", false);
    }

    protected override void Think()
    {
        if (timeBtwAttack <= 0)
        {
            enemyState = EnemyStates.Attacking;
            if (tempTimeSpentAttacking <= 0)
            {
                enemyState = EnemyStates.Idle;
                if (tempTimeSpentIdle <= 0)
                {
                    enemyState = EnemyStates.Walking;
                    tempTimeSpentAttacking = timeSpentAttacking;
                    tempTimeSpentIdle = timeSpentIdle;
                    timeBtwAttack = startTimeBtwAttack;
                }
                else
                {
                    tempTimeSpentIdle -= Time.deltaTime;
                }          
            }
            else
            {
                tempTimeSpentAttacking -= Time.deltaTime;
            }
        }
        else
        {
            enemyState = EnemyStates.Walking;
            timeBtwAttack -= Time.deltaTime;
        }

        if (health <= 0)
        {
            enemyState = EnemyStates.Dead;
        } 

        switch (enemyState)
        {
            case EnemyStates.Walking:
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isDead", false);
                ResumeMovement();
                EnemyWalk();
                break;
            case EnemyStates.Attacking:
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);
                anim.SetBool("isDead", false);
                StopMovement();
                EnemyAttack();
                break;
            case EnemyStates.Idle:
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isDead", false);
                StopMovement();
                break;
            case EnemyStates.Dead:
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isDead", true);
                StopMovement();
                EnemyDie();
                break;

            default:
                break;
        }
    }
}

