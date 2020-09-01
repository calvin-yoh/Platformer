using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private float isUnderDebuff = 0f;

    private bool isStunned = false;
    private float stunTime;


    private bool isKnockedBack = false;
    private float knockback;
    private float knockbackLength;
    private bool knockFromRight;

    private Rigidbody2D myRigidBody = null;

    private void Awake()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isUnderDebuff > 0)
        {
            DoEffect();
        }
        else
        {
            Think();
        }
    }
    public abstract void EnemyDie();

    public abstract void TakeDamage(float damageTaken);

    protected abstract void EnemyWalk();

    protected abstract void EnemyAttack();

    protected void KnockbackPlayer(GameObject player)
    {
        Debug.Log("hitPlayer");
        var playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.knockbackCount = playerMovement.knockbackLength;

        if (player.transform.position.x < transform.position.x)
        {
            playerMovement.knockFromRight = true;
        }
        else
        {
            playerMovement.knockFromRight = false;
        }
    }

    public void StopMovement()
    {
        myRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    public void ResumeMovement()
    {
        transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    protected abstract void Think();

    private void DoEffect()
    {
        CheckStunned();
        CheckKnockedBack();
    }

    public void ApplyStunned(float givenStunnedTime)
    {
        if (!isStunned)
        {
            isUnderDebuff++;
        }
        isStunned = true;
        stunTime = givenStunnedTime;
    }

    public void ApplyKnockedBack(float givenKnockbackLength, bool isKnockedFromRight)
    {
        if(!isKnockedBack)
        {
            isUnderDebuff++;
        }
        isKnockedBack = true;
        knockbackLength = givenKnockbackLength;
        knockFromRight = isKnockedFromRight;
    }

    private void CheckStunned()
    {
        if (isStunned)
        {
            StopMovement();
            stunTime -= Time.deltaTime;
            if (stunTime <= 0)
            {
                isStunned = false;
                ResumeMovement();
                isUnderDebuff--;
            }
        }
    }

    private void CheckKnockedBack()
    {
        if (isKnockedBack)
        {
            if (knockFromRight)
            {
                myRigidBody.velocity = new Vector2(-knockback, 0f);
            }
            if (!knockFromRight)
            {
                myRigidBody.velocity = new Vector2(knockback, 0f);
            }
            knockbackLength -= Time.deltaTime;
            if (knockbackLength <= 0)
            {
                isKnockedBack = false;
                isUnderDebuff--;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collidedPlayer");
        if (other.gameObject.tag == "Player")
        {
            KnockbackPlayer(other.gameObject);
        }
    }
}
