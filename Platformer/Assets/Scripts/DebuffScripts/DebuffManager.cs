using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    [SerializeField] private Debuff stunnedDebuff = null;

    private void OnEnable()     // subscribe event
    {
        DebuffEvents.OnCallStunnedDebuff += CallStunnedDebuff;
    }

    private void OnDisable()    // unsubscribe event
    {
        DebuffEvents.OnCallStunnedDebuff -= CallStunnedDebuff;
    }

    private void CallStunnedDebuff(GameObject enemyHit)
    {
        var tempGameobject = Instantiate(stunnedDebuff.myParticleSystem.gameObject, enemyHit.transform.position, Quaternion.identity);
        Destroy(tempGameobject, stunnedDebuff.GetDebuffTime());
    }
}
