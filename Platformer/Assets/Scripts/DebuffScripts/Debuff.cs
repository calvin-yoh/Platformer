using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Debuff : ScriptableObject
{
    public abstract void Apply(Enemy enemyToDebuff);
}
