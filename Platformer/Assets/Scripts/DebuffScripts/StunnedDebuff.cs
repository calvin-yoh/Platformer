using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedDebuff : Debuff
{
    [SerializeField] private ParticleSystem stunPS;
    public override void Apply(Enemy enemyToDebuff)
    {
        stunPS.Play();
    }
}
