using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Respawn")
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
