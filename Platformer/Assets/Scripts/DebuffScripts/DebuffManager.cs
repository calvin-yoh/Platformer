using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    [SerializeField] private Debuff stunnedDebuff = null;
    [SerializeField] private Debuff knockbackDebuff = null;

    private void OnEnable()     // subscribe event
    {
        DebuffEvents.OnCallStunnedDebuff += CallStunnedDebuff;
        DebuffEvents.OnCallKnockbackDebuff += CallKnockbackDebuff;
    }

    private void OnDisable()    // unsubscribe event
    {
        DebuffEvents.OnCallStunnedDebuff -= CallStunnedDebuff;
        DebuffEvents.OnCallKnockbackDebuff -= CallKnockbackDebuff;
    }

    private void CallStunnedDebuff(GameObject enemyHit)
    {
        var tempGameobject = Instantiate(stunnedDebuff.myParticleSystem.gameObject, enemyHit.transform.position, Quaternion.identity);
        enemyHit.GetComponent<Enemy>().ApplyStunned(stunnedDebuff.GetDebuffTime());
        Destroy(tempGameobject, stunnedDebuff.GetDebuffTime());
    }

    private void CallKnockbackDebuff(GameObject enemyHit, GameObject player)
    {
        if (player.transform.position.x < enemyHit.transform.position.x)
        {
            enemyHit.GetComponent<Enemy>().ApplyKnockedBack(knockbackDebuff.GetDebuffDistance(), false);
        }
        else
        {
            enemyHit.GetComponent<Enemy>().ApplyKnockedBack(knockbackDebuff.GetDebuffDistance(), true);
        }       
    }
}
