using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerInteraction interact;
    [SerializeField] private PlayerAttack attack;

    private float health = 100f;
    private string weapon = null;


    private void Awake()
    {
        if (weapon == null)
        {
            attack.enabled = false;
        }
        else 
        {
            attack.enabled = true;
        }        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
