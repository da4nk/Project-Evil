using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// movement script In c# for player movement
public class movement : MonoBehaviour
{
    public float speed = 11f;
    private Rigidbody player;
     public float radius = 0.5f;
    public float height = 2f;
    public int player_size = 2;


    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");



        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
        }

        float distance = speed * Time.deltaTime;
        Vector3 localMovement = new Vector3(horizontal, 0f, vertical);
        Vector3 globalMovement = transform.TransformDirection(localMovement).normalized;

        // make boolean to check if player has hit something

        Vector3 position = transform.position + Vector3.up * (height / 2f - radius);
        Vector3 direction = transform.forward;

        RaycastHit hit;

        // Cast the capsule and get the hit information
        bool collided = Physics.SphereCast(transform.position, radius, transform.forward, out hit, distance);
        bool collided2 = Physics.SphereCast(transform.position, radius, -transform.forward, out hit, distance);
        bool collided3 = Physics.SphereCast(transform.position, radius, transform.right, out hit, distance);
        bool collided4  = Physics.SphereCast(transform.position, radius, -transform.right, out hit, distance);






        if ((collided || collided2 || collided3 || collided4))
        {
            transform.position += globalMovement * speed * Time.deltaTime;
        }
     

    }
}
