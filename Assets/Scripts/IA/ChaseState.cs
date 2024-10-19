using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState (S)", menuName = "ScriptableObject/State/ChaseState")]              //crea una opcion nueva en el menu para
public class ChaseState : State
{
    public override State Run(GameObject owner)
    {

        State nextState = ChecksActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        GameObject target = owner.GetComponent<TargetReference>().target;
        navMeshAgent.SetDestination(target.transform.position);

        return nextState;
    }
}
