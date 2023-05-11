using UnityEngine;
using UnityEngine.AI;

public class ai : MonoBehaviour
{
    public float probeDistance = 10f;
    public float searchRadius = 20f;
    public float chaseDistance = 30f;
    public float moveSpeed = 5f;

    private NavMeshAgent agent;
    private Transform playerTransform;
    private Vector3 lastKnownPlayerPosition;
    private bool playerInSight = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        lastKnownPlayerPosition = transform.position;
    }

    void Update()
    {
        // If the player is in sight, chase them
        if (playerInSight)
        {
            agent.SetDestination(playerTransform.position);
            lastKnownPlayerPosition = playerTransform.position;
        }
        // Otherwise, probe the area and search for the player
        else
        {
            if (Vector3.Distance(transform.position, lastKnownPlayerPosition) > chaseDistance)
            {
                agent.SetDestination(lastKnownPlayerPosition);
            }
            else
            {
                // Check if the player is within the search radius
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, searchRadius);
                foreach (Collider hitCollider in hitColliders)
                {
                    if (hitCollider.CompareTag("Player"))
                    {
                        lastKnownPlayerPosition = hitCollider.transform.position;
                        playerInSight = true;
                        break;
                    }
                }

                // If the player isn't in sight, probe the area
                if (!playerInSight)
                {
                    Vector3 probeDirection = Random.insideUnitSphere;
                    probeDirection.y = 0f;
                    agent.SetDestination(transform.position + probeDirection * probeDistance);
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        // If the player enters the monster's trigger zone, check if they're in sight
        if (other.CompareTag("Player"))
        {
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle < 90f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + Vector3.up, direction.normalized, out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        playerInSight = true;
                        lastKnownPlayerPosition = hit.collider.transform.position;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the player exits the monster's trigger zone, stop chasing them
        if (other.CompareTag("Player"))
        {
            playerInSight = false;
        }
    }
}
