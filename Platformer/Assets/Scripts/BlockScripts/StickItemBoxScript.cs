using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickItemBoxScript : BreakableBlockScript
{
    [SerializeField] private GameObject stickItem = null;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (CheckIfBreak(col))
        {
            StickItemBoxDie();
        }
    }

    void StickItemBoxDie()
    {
        Instantiate(stickItem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
