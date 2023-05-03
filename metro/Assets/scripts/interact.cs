using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    public float pickupDistance = .2f; // Maximum distance the player can pick up an object from
    public Transform hand; // The player's hand transform
    public Rigidbody flashlight;
    bool isNearObject = false;
    public float rotateSpeed = 48f;
    [SerializeField] Transform Camera;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickupable"))
        {
            isNearObject = true;
        }
      

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearObject = false;
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.X) && isNearObject)
        {
            flashlight.transform.position = hand.transform.position;
            flashlight.transform.parent = hand;
            flashlight.transform.forward = -Camera.transform.up;
        }
    
    }
}