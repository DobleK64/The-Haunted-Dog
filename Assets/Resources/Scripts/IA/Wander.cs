using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "WanderState (S)", menuName = "ScriptableObject/State/WanderState")]
public class WanderState : State
{    
    public float range;
    public Vector3 centrePoint;
    public string blendParameter;

    private float currentTime;
    public override State Run(GameObject owner)
    {
        currentTime += Time.deltaTime;
        State nextState = ChecksActions(owner);
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        Animator animator = owner.GetComponent<Animator>();
        //NavMeshObstacle navMeshObstacle = owner.GetComponent<NavMeshObstacle>();
        
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance || currentTime > 7)
        {
            Vector3 point;
            if(RandomPoint(centrePoint, range, out point))
            {
                navMeshAgent.SetDestination(point);
            }
            currentTime = 0;
        }
        
        bool RandomPoint(Vector3 center, float range, out Vector3 result)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit , 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
            result = Vector3.zero;
            return false;
        }
        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed);
        return nextState;
    }
}
