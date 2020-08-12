using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebuffEvents 
{
    public static event Action<GameObject> OnCallStunnedDebuff;
    public static event Action OnGetStunnedDebuffTime;

    public static void RaiseCallStunnedDebuffEvent(GameObject enemyHit) => OnCallStunnedDebuff?.Invoke(enemyHit);
    public static void RaiseGetStunnedDebuffTime() => OnGetStunnedDebuffTime?.Invoke();
}
