using UnityEngine;
using UnityEngine.AI;

public class ai : MonoBehaviour
{
    public float searchRadius = 30f;
    public float probeDistance = 100f;
    public float chaseDistance = 50f;
    public float moveSpeed = 20f;
    public float chaseSpeed = 50f;
    public float catchDistance = 50f;

    private NavMeshAgent agent;
    private Transform playerTransform;
    private Vector3 lastKnownPlayerPosition;
    private bool playerInSight;
    private AudioSource audioSource;
    public AudioClip chaseSound;
    public AudioClip jumpScareSound;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        lastKnownPlayerPosition = transform.position;
        playerInSight = false;
        audioSource = GetComponent<AudioSource>();
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
            bool foundPlayer = Physics.Raycast(transform.position, playerTransform.position - transform.position, out hit, Mathf.Infinity);
            
            if (foundPlayer || Vector3.Distance(agent.transform.position, lastKnownPlayerPosition) <= searchRadius)
            {
                if (Vector3.Distance(agent.transform.position, playerTransform.position) <= chaseDistance)
                {
                    playerInSight = true;
                    lastKnownPlayerPosition = playerTransform.position;
                    agent.speed = chaseSpeed;
                    agent.SetDestination(lastKnownPlayerPosition);
                    
                    if (!audioSource.isPlaying)
                        audioSource.PlayOneShot(chaseSound);
                }
            }
            else
            {
                if (playerInSight)
                {
                    if (Vector3.Distance(agent.transform.position, lastKnownPlayerPosition) > chaseDistance)
                    {
                        agent.speed = moveSpeed;
                        agent.SetDestination(lastKnownPlayerPosition);
                        
                        if (!audioSource.isPlaying)
                            audioSource.PlayOneShot(chaseSound);
                    }
                }
                else
                {
                    if (Vector3.Distance(agent.transform.position, playerTransform.position) <= catchDistance)
                    {
                        if (!audioSource.isPlaying)
                            audioSource.PlayOneShot(jumpScareSound);
                    }
                
                    if (Vector3.Distance(agent.transform.position, lastKnownPlayerPosition) <= searchRadius)
                    {
                        Vector3 probeDirection = Random.insideUnitSphere;
                        probeDirection.y = 0f;
                        agent.speed = moveSpeed;
                        agent.SetDestination(transform.position + (probeDirection * probeDistance));
                    }
                    else
                    {
                        agent.speed = moveSpeed;
                        agent.SetDestination(lastKnownPlayerPosition);
                    }
                }
            }
        }
    }
}
