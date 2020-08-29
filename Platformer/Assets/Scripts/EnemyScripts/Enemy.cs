using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private bool isUnderDebuff = false;

    private void Update()
    {
        if (isUnderDebuff)
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

    protected void ApplyKnockBack(Collision2D player)
    {
        Debug.Log("hitPlayer");
        var playerMovement = player.gameObject.GetComponent<PlayerMovement>();
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
        transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    public void ResumeMovement()
    {
        transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void PlayDebuffEffect()
    {
        DebuffEvents.RaiseCallStunnedDebuffEvent(this.gameObject);
    }

    protected abstract void Think();

    private void DoEffect()
    { 
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collidedPlayer");
        if (other.gameObject.tag == "Player")
        {
            ApplyKnockBack(other);
        }
    }
}
