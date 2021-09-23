using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Edgar_Manager : MonoBehaviour
{

    private NavMeshAgent agent;
    public List<Target_Point> targetPoints = new List<Target_Point>();
    public int indexNextDestination = 0;
    private Vector3 actualDestination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.avoidancePriority = Random.Range(1,100);
        agent.speed = Random.Range(1f,6f);
        NextDestination();
    }

    
    void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            NextDestination();
        }
    }
    private void NextDestination()
    {
        int oldIndex = indexNextDestination;
        
        while(oldIndex == indexNextDestination &&targetPoints.Count >1)
        {
            indexNextDestination = Random.Range(0,targetPoints.Count);
        }
        actualDestination = targetPoints[indexNextDestination].GivePoint();
        agent.SetDestination(actualDestination);
        
        if(indexNextDestination >= targetPoints.Count)
        {
            indexNextDestination =0;
        }
                
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


