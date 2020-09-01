using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    [SerializeField] private float forceMultiplier = 0f;
    [SerializeField] private Animator anim = null;

    public Transform attackPos;
    public float trialAttackRangeX;
    public float trialAttackRangeY;
    public Transform originOfExplode;
    public LayerMask whatIsEnemy;

    public void CheckAttack(Weapon currWeapon)
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("PlayerAttack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, 
                                                 new Vector2(currWeapon.GetWeaponRangeX(), currWeapon.GetWeaponRangeY())
                                                    , 0, whatIsEnemy);
                foreach (Collider2D col in enemiesToDamage)
                {
                    col.GetComponent<Enemy>().TakeDamage(currWeapon.GetDamage());
                    switch (currWeapon.GetWeaponName())
                    {
                        case "Stick":
                            Debug.Log("PlayerStickAttack");
                            KnockbackEnemy(col.gameObject);
                            break;
                        case "Pan":
                            StunEnemy(col.gameObject);
                            break;
                        default:
                            break;
                    }                    
                    //Vector2 force =  (col.transform.position - originOfExplode.position) * forceMultiplier;
                    //Rigidbody2D rb = col.transform.GetComponent<Rigidbody2D>();
                    //rb.AddForce(force, ForceMode2D.Impulse);
                }
                anim.SetBool("isAttacking", true);
                timeBtwAttack = currWeapon.GetTimeBtwAttack();              
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

    private void StunEnemy(GameObject enemyHit)
    {
        DebuffEvents.RaiseStunnedDebuffEvent(enemyHit);
    }

    private void KnockbackEnemy(GameObject enemyHit)
    {
        DebuffEvents.RaiseKnockbackDebuffEvent(enemyHit, this.gameObject);
    }
}
