using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxScript : BreakableBlockScript
{
    [SerializeField] private GameObject itemToSpawn = null;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (CheckIfBreak(col))
        {
            StickItemBoxDie();
        }
    }

    void StickItemBoxDie()
    {
        Instantiate(itemToSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
