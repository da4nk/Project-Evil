using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update

    // make the player

    Transform orientation;
    public Rigidbody player;

    // player walking speed
    public float speed = 11f;


    public Vector3 moveDirection;


    void Start()
    {
        // select the body of player
        player = GetComponent<Rigidbody>();

        // grabs the camera child from the player 
        orientation = GetComponentInChildren<Camera>().transform;

    }

    // Update is called once per frame
    void Update()
    { 
        float horizontal = 0f;
        float vertical = 0f;

    
       


        // movement below
        
        if (Input.GetKey(KeyCode.A))
        {

            horizontal = -1f;
            
        }
        if(Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1f;
        }

        // calculates the direction of the player for the movement
        moveDirection = (orientation.TransformDirection(new Vector3(horizontal, 0, vertical))).normalized;
        // keeps the player on the ground
        moveDirection.y = 0;
        

        // applies movement to player position
        player.transform.localPosition += moveDirection * speed * Time.deltaTime;

    }
}
