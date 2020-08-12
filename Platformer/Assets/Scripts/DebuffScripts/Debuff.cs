using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Debuff", menuName = "Debuff")]
public class Debuff : ScriptableObject
{
    [SerializeField] private float debuffTime;
    public ParticleSystem myParticleSystem;
    public Sprite mySprite = null;

    public void Apply(Enemy enemyToDebuff)
    {
        return;
    }

    public float GetDebuffTime()
    {
        return debuffTime;
    }
}
