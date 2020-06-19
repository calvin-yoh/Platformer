using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//わたしのともだちはばかです。

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5.0f;

    public Vector2 jump;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Impulse);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}