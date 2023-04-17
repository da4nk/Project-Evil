using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_y : MonoBehaviour
{
    public Vector3 rotation;
    public float sensitivity = 6;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        


    }

    // Update is called once per frame
    void Update()
    {

        rotation.y += Input.GetAxis("Mouse X") * sensitivity;
        transform.localRotation = Quaternion.Euler(0, rotation.y, 0);
    }
}
