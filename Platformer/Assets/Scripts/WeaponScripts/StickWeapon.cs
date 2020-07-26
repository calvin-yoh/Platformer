﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickWeapon : Weapon
{
    [SerializeField] private float damageToDeal = 0f;
    [SerializeField] private AnimationClip attackAnim = null;
    [SerializeField] private float attackRangeX = 3.38f;
    [SerializeField] private float attackRangeY = 1.87f;

    private string weaponName = "Stick";
    private float speed = 0.5f;

    public override float GetDamage()
    {
        return damageToDeal;
    }

    public override AnimationClip GetAttackAnimClip()
    {
        return attackAnim;
    }

    public override string GetWeaponName()
    {
        return weaponName;
    }

    public override Weapon GetWeaponType()
    {
        return this;
    }

    public override float GetWeaponRangeX()
    {
        return attackRangeX;
    }

    public override float GetWeaponRangeY()
    {
        return attackRangeY;
    }
}
