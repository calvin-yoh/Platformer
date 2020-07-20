using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggoEnemy : EnemyMovement
{
    [SerializeField] private float health = 50f;

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

    void Start()
    {
        transform.localScale = new Vector2(transform.localScale.x * moveDirection, transform.localScale.y);
        moveSpeed *= moveDirection;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyWalk();
        CheckHealth();
        CheckIfAttack();
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            EnemyDie();
        }
    }

    public override void EnemyDie()
    {
        anim.SetBool("isDead", true);
        Destroy(gameObject, 0.5f);
    }

    public override void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        Debug.Log(health);
    }

    protected override void EnemyWalk()
    {
        anim.SetBool("isWalking", true);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);

        if (Physics2D.Linecast(sightTop.position, sightBot.position, detectWhat))
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
        }
    }

    protected override void EnemyAttack()
    {
        anim.SetBool("isAttacking", true);
        anim.SetBool("isWalking", false);
        Debug.Log("attacking");
        Collider2D col = Physics2D.OverlapCircle(attackOrigin.position, attackRange, lookForPlayer);
        if (col != null)
        {
            col.GetComponent<PlayerInteraction>().PlayerDie();
            Vector2 force = (col.transform.position - originOfExplode.position) * forceMultiplier;
            Rigidbody2D rb = col.transform.GetComponent<Rigidbody2D>();
            rb.AddForce(force); 
        }
    }

    private void CheckIfAttack()
    {
        if (timeBtwAttack <= 0)
        {
            EnemyAttack();
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            anim.SetBool("isAttacking", false);
        }
    }

    //used in all FrogAnimations to control ability of movement. Will need to revamp later 
    public void StopMovement(int active)
    {
        if (active == 1)
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX 
                | RigidbodyConstraints2D.FreezeRotation;
        if (active == 0)
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
