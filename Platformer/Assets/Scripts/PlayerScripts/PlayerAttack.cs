using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack = 0f;
    [SerializeField] private float forceMultiplier = 0f;
    [SerializeField] private Animator anim = null;

    public Transform attackPosA;
    public Transform attackPosB;
    public Transform originOfExplode;
    public LayerMask whatIsEnemy;
    public float attackRange;

    public void CheckAttack(float damage)
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapAreaAll(attackPosA.position, attackPosB.position, whatIsEnemy);
                foreach (Collider2D col in enemiesToDamage)
                {
                    col.GetComponent<EnemyMovement>().TakeDamage(damage);
                    Vector2 force = (col.transform.position - originOfExplode.position) * forceMultiplier;
                    Rigidbody2D rb = col.transform.GetComponent<Rigidbody2D>();
                    rb.AddForce(force);
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
}
