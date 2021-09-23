using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Simon_Target : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.avoidancePriority = Random.Range(1,100);
        agent.speed = Random.Range(1f,6f);

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
    
    private void OnDrawGizmos() 
    {
        if (agent != null)
        {
            Gizmos.DrawSphere(transform.position + Vector3.up *2,
         0.05f + (100-agent.avoidancePriority)*0.01f);
        }
        
    }
}
