using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headbobbing : MonoBehaviour
{
    public float amplitude = 0.1f; // amplitude of head bobbing motion
    public float frequency = 1.0f; // frequency of head bobbing motion
    public float horizontalOffset = 0.0f; // horizontal offset of head bobbing motion
    public float verticalOffset = 0.0f; // vertical offset of head bobbing motion

    private Vector3 initialPosition; // initial position of the camera

    void Start()
    {
        initialPosition = transform.localPosition; // store initial position of the camera
    }

    void Update()
    {
        // Calculate head bobbing motion based on time and defined variables
        float horizontalBob = Mathf.PingPong(Time.time * frequency, amplitude) + horizontalOffset;
        float verticalBob = Mathf.PingPong(Time.time * frequency * 2, amplitude) + verticalOffset;

        // Update camera position with head bobbing motion
        transform.localPosition = initialPosition + new Vector3(horizontalBob, verticalBob, 0.0f);
    }
}
