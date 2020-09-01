using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebuffEvents 
{
    public static event Action<GameObject> OnCallStunnedDebuff;
    public static event Action OnGetStunnedDebuffTime;

    public static event Action<GameObject, GameObject> OnCallKnockbackDebuff;
    public static event Action OnGetKnockbackDistance;

    public static void RaiseStunnedDebuffEvent(GameObject enemyHit) => OnCallStunnedDebuff?.Invoke(enemyHit);
    public static void RaiseGetStunnedDebuffTime() => OnGetStunnedDebuffTime?.Invoke();

    public static void RaiseKnockbackDebuffEvent(GameObject enemyHit, GameObject player) => OnCallKnockbackDebuff?.Invoke(enemyHit, player);
    public static void RauseGetKnockbackDistance() => OnGetKnockbackDistance?.Invoke();


}
