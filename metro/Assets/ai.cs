using UnityEngine;
using UnityEngine.AI;

public class ai : MonoBehaviour
{
    public float probdistance = 30f;
    public float searchradius = 30f;
    public float chasedistance = 50f;
    public float movespeed = 20f;
    public float chasespeed = 50;

    private NavMeshAgent agent;
    private Transform playerTransform;
    private Vector3 lastKnownPlayerPosition;
    private bool playerInSight = false;
    private float laser = 100f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        lastKnownPlayerPosition = playerTransform.position;
    }

    private void Update()
    {
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found!");
            return;
        }

        if (playerTransform != null)
        {
            RaycastHit hit;
            bool foundPlayer = Physics.Raycast(transform.position, playerTransform.position - transform.position, out hit, laser);
            if (foundPlayer)
            {
                playerInSight = true;
                lastKnownPlayerPosition = playerTransform.position;
                agent.SetDestination(lastKnownPlayerPosition);
                if (playerInSight)
                {
                    if (Vector3.Distance(agent.transform.position, lastKnownPlayerPosition) > chasedistance)
                    {
                        agent.SetDestination(lastKnownPlayerPosition);
                    }

                }
            }
            else
            {
                Vector3 probeDirection = Random.insideUnitSphere;
                probeDirection.y = 0f;
                agent.SetDestination(transform.position + (probeDirection * probdistance));
            }

        }
    }
}
