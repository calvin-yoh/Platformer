using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask detectWhat;
    [SerializeField] private Transform sightTop;
    [SerializeField] private Transform sightBot;
    [SerializeField] private Transform weakness;
    private bool colliding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        colliding = Physics2D.Linecast(sightTop.position, sightBot.position, detectWhat);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        float height = col.contacts[0].point.y - weakness.position.y;

        if (col.gameObject.tag == "Player")  
        {
            if (height > 0)
            {
                col.rigidbody.AddForce(new Vector2(0, 2000));
                Die();
            }
            else 
            {
                col.gameObject.GetComponent<PlayerInteraction>().PlayerDie();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
