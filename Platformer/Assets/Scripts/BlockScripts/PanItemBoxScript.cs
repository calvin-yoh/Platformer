using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanItemBoxScript : BreakableBlockScript
{
    [SerializeField] private GameObject panItem = null;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (CheckIfBreak(col))
        {
            StickItemBoxDie();
        }
    }

    void StickItemBoxDie()
    {
        Instantiate(panItem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
