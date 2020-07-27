using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private void Start()
    {
        IgnoreCollision();
    }

    public abstract string GetWeaponName();

    public abstract float GetDamage();

    public abstract AnimationClip GetAttackAnimClip();

    public abstract AnimationClip GetIdleAnimClip();

    public abstract Weapon GetWeaponType();

    public abstract float GetWeaponRangeX();

    public abstract float GetWeaponRangeY();

    public abstract float GetTimeBtwAttack();

    private void IgnoreCollision()
    {
        //Physics2D.IgnoreLayerCollision(14, 8, true);
        Physics2D.IgnoreLayerCollision(14, 11, true);
        Physics2D.IgnoreLayerCollision(14, 12, true);
        Physics2D.IgnoreLayerCollision(14, 13, true);
    }
}
