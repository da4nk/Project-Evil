using UnityEngine;

public class pickup : MonoBehaviour
{
    [SerializeField] private Transform hand;
    public Transform gun;
    public bool isHolding = false;
    public GameObject text;

    private void Start()
    {
        // Find the gun object by tag
        gun = GameObject.FindGameObjectWithTag("Pickupable").transform;
    }

    private void Update()
    {
        if (!isHolding)
        {
            // If the player is close enough to the gun, display the pickup prompt
            float distance = Vector3.Distance(transform.position, gun.position);
            if (distance < 2f)
            {
                text.SetActive(true);
            }
            else
            {
                text.SetActive(false);
            }

            // If the player is close enough and presses the F key, pick up the gun
            if (distance < 2f && Input.GetKeyDown(KeyCode.F))
            {
                PickupGun();
            }
        }
        else
        {
            text.SetActive(false);

            // If the player is holding the gun and presses the F key, drop it
            if (Input.GetKeyDown(KeyCode.F))
            {
                DropGun();
            }
        }
    }

    private void PickupGun()
    {

        
        // Parent the gun to the hand
        gun.SetParent(hand);

        // Reset the position and rotation of the gun relative to the hand
        gun.localPosition = Vector3.zero;
        gun.localRotation = Quaternion.identity;

        // Disable physics on the gun
        Rigidbody gunRigidbody = gun.GetComponent<Rigidbody>();
        gunRigidbody.isKinematic = true;
                        gun.transform.Rotate(0f, 180f, 0f);


        // Indicate that the gun is now being held
        isHolding = true;
    }

    private void DropGun()
    {
        // Unparent the gun from the hand
        gun.SetParent(null);

        // Enable physics on the gun
        Rigidbody gunRigidbody = gun.GetComponent<Rigidbody>();
        gunRigidbody.isKinematic = false;

        // Indicate that the gun is no longer being held
        isHolding = false;
    }
}
