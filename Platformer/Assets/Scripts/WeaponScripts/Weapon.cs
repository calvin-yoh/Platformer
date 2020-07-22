using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private Vector2 target;

    private void Start()
    {
        target.x = transform.position.x;
        target.y = transform.position.y + transform.localScale.y;
    }

    public abstract string GetWeaponName();

    public abstract float GetDamage();

    public abstract float GetAttackRange();

    protected void MoveToPosition()
    {
        transform.position = Vector2.Lerp(transform.position, target, Time.fixedDeltaTime);
    }

    public abstract AnimationClip GetAttackAnimClip();

    public abstract Weapon GetWeaponType();   
}
