using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack = 0f;
    [SerializeField] private float forceMultiplier = 0f;
    [SerializeField] private Animator anim = null;

    public Transform attackPos;
    public float trialAttackRangeX;
    public float trialAttackRangeY;
    public Transform originOfExplode;
    public LayerMask whatIsEnemy;

    public void CheckAttack(float damage, float attackRangeX, float attackRangeY)
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemy);
                foreach (Collider2D col in enemiesToDamage)
                {
                    col.GetComponent<EnemyMovement>().TakeDamage(damage);
                    Vector2 force =  (col.transform.position - originOfExplode.position) * forceMultiplier;
                    Rigidbody2D rb = col.transform.GetComponent<Rigidbody2D>();
                    rb.AddForce(force, ForceMode2D.Impulse);
                }
                anim.SetBool("isAttacking", true);
                timeBtwAttack = startTimeBtwAttack;
                Debug.Log("PlayerAttack");
            }
        }
        else
        {
            anim.SetBool("isAttacking", false);
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(trialAttackRangeX, trialAttackRangeY, 1));
    }

}
