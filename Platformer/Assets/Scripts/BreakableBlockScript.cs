using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlockScript : MonoBehaviour
{
    [SerializeField] private Transform botWeakness = null;

    void OnCollisionEnter2D(Collision2D col)
    {   
        if (col.gameObject.tag == "Player")
        {
            float heightBot = col.contacts[0].point.y - botWeakness.position.y;
            Debug.Log(col.GetType());
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
