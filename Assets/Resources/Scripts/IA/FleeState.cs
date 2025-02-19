using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "FleeState (S)", menuName = "ScriptableObject/State/FleeState")]
public class FleeState : State
{
    public override State Run(GameObject owner)
    {
        State state = ChecksActions(owner);
        TargetReference targetReference = owner.GetComponent<TargetReference>();
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();

        Vector3 flee = (owner.transform.position - targetReference.target.transform.position).normalized;
        navMeshAgent.SetDestination(owner.transform.position + flee * 10);

        return state;
    }
}
