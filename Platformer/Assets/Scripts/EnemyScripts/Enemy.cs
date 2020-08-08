using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void EnemyDie();

    public abstract void TakeDamage(float damageTaken);

    protected abstract void EnemyWalk();

    protected abstract void EnemyAttack();
}
