using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class navmeshcon : MonoBehaviour
{
    private NavMeshAgent agent;
    private float raycastDistance = 1.0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Cast a ray downwards to check if the agent is grounded
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, NavMesh.AllAreas))
        {
            // Move the agent to the hit point plus an offset to keep it on the ground
            Vector3 targetPosition = hit.point + (Vector3.up * agent.baseOffset);
            agent.SetDestination(targetPosition);
        }
    }
}
