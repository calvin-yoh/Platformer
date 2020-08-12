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
}
