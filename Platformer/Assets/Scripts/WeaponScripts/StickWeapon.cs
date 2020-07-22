using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickWeapon : Weapon
{
    [SerializeField] private float damageToDeal = 0f;
    [SerializeField] private float attackRange = 0f;
    [SerializeField] private AnimationClip attackAnim = null;

    private string weaponName = "Stick";
    private float speed = 0.5f;
    
    // Update is called once per frame
    void Update()
    {
        MoveToPosition();
    }

    public override float GetDamage()
    {
        return damageToDeal;
    }

    public override AnimationClip GetAttackAnimClip()
    {
        return attackAnim;
    }

    public override float GetAttackRange()
    {
        return attackRange;
    }

    public override string GetWeaponName()
    {
        return weaponName;
    }

    public override Weapon GetWeaponType()
    {
        return this;
    }
}
