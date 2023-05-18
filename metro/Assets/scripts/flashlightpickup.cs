using UnityEngine;

public class flashlightpickup : MonoBehaviour
{
    [SerializeField] private Transform hand;
    public Transform flashlight;
    public bool isHolding = false;
    public GameObject text;
    private void Start()
    {
        // Find the flashlight object by tag
        flashlight = GameObject.FindGameObjectWithTag("Pickupable").transform;

    }


    private void Update()
    {
        if (!isHolding)
        {
            // If the player is close enough to the flashlight, pick it up
            float distance = Vector3.Distance(transform.position, flashlight.position);
            if(distance < 2f)
            {
                text.SetActive(true);
            }
            else if(distance > 2f)
            {
                text.SetActive(false);
            }
            if (distance < 5f && Input.GetKeyDown(KeyCode.F))
            {
                flashlight.SetParent(hand);
                flashlight.localPosition = Vector3.zero;
                flashlight.localRotation = Quaternion.identity;
                flashlight.transform.Rotate(0f, 180f, 0f);
                flashlight.GetComponent<Rigidbody>().isKinematic = true;
                isHolding = true;
            }
        }

        else
        {
           
            text.SetActive(false);
           
            // if the player is holding the flashlight, and presses f again drop it
            if (Input.GetKeyDown(KeyCode.F))
            {
               

                // makes the player no longer the parent of the flashlight
                flashlight.SetParent(null);

                // selects the kinematic body of flashlight and turns it off
                flashlight.GetComponent<Rigidbody>().isKinematic = false;

                // indicate that the flashlight is no longer held
                isHolding = false;
            }
        }
    }
}
