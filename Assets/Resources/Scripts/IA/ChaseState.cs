using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState (S)", menuName = "ScriptableObject/State/ChaseState")]              //crea una opcion nueva en el menu para
public class ChaseState : State
{
    public string blendParameter;

    public override State Run(GameObject owner)
    {

        State nextState = ChecksActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        GameObject target = owner.GetComponent<TargetReference>().target;
        navMeshAgent.SetDestination(target.transform.position);
        Animator animator = owner.GetComponent<Animator>();
        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed); //animacion gradual que depende de la velocidad

        return nextState;
    }
}
//float distanceToTarget = Vector3.Distance(owner.transform.position, target.transform.position);
//if ( distanceToTarget < 0.5f )
//{
//    int valor = Random.Range(0, 3);
//    if(valor == 0)
//    {
//        animator.SetBool("Attack", true);
//    }
//    else if (valor ==1)
//    {
//        animator.SetBool("Attack2", true);
//    }
//    else
//    {
//        animator.SetBool("Attack3", true);
//    }
//}
//else
//{
//    animator.SetBool("Attack", true);
//    animator.SetBool("Attack2", true);
//    animator.SetBool("Attack3", true);
//}