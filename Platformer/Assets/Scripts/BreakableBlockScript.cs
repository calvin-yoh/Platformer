using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlockScript : MonoBehaviour
{
    [SerializeField] private Transform botWeakness;

    void OnCollisionEnter2D(Collision2D col)
    {
        float heightBot = col.contacts[0].point.y - botWeakness.position.y;

        if (col.gameObject.tag == "Player")
        {
            if (heightBot < 0)
            {
                BreakableBlockDie();
            }
        }
    }

    void BreakableBlockDie()
    {
        Destroy(gameObject);
    }
}
