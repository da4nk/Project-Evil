using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    // Start is called before the first frame update
    public new GameObject light;
    bool LightIson = false;
    void Start()
    {
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (LightIson == false)
            {


                light.SetActive(true);
                LightIson = true;
                

                
            }
            else 
            {

                light.SetActive(false);
                LightIson = false;


            }
        }


        
    }
}
