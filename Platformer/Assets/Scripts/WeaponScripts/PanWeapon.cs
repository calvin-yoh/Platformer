using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanWeapon : Weapon
{
    [SerializeField] private float damageToDeal = 0f;
    [SerializeField] private AnimationClip attackAnim = null;
    [SerializeField] private float attackRangeX = 2.24f;
    [SerializeField] private float attackRangeY = 2.72f;

    private string weaponName = "Pan";
    private float speed = 0.5f;

    public override AnimationClip GetAttackAnimClip()
    {
        return attackAnim;
    }

    public override float GetDamage()
    {
        return damageToDeal;
    }

    public override string GetWeaponName()
    {
        return weaponName;
    }

    public override float GetWeaponRangeX()
    {
        return attackRangeX;
    }

    public override float GetWeaponRangeY()
    {
        return attackRangeY;
    }

    public override Weapon GetWeaponType()
    {
        return this;
    }
}
