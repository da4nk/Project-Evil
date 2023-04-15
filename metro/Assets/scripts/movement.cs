using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody player;
    public float speed = 11f;
    void Start()
    {
        // select the body of player
        player = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
