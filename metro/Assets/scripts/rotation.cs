using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 turning;
 

    public float sensitivity = 6; 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    public void Update()
    {
        // get the mouse position and then apply that to the object in unity rotation multiplied by the sensitivty
        turning.x += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(0,-turning.x,0);
       
        turning.x = Mathf.Clamp(turning.x, -90, 90);


    }
}
