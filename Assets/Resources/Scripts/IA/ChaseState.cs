using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState (S)", menuName = "ScriptableObject/State/ChaseState")]              //crea una opcion nueva en el menu para
public class ChaseState : State
{
    public string blendParameter;
    public AudioClip AttackClip, AttackClip2, AttackClip3;
    private float currentTime;
    //private int index = 1;
    public override State Run(GameObject owner)
    {
        currentTime += Time.deltaTime;
        State nextState = ChecksActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        GameObject target = owner.GetComponent<TargetReference>().target;
        navMeshAgent.SetDestination(target.transform.position);
        Animator animator = owner.GetComponent<Animator>();
        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed); //animacion gradual que depende de la velocidad
        Vector3 directionToTarget = (target.transform.position - owner.transform.position).normalized;
        float distanceToTarget = Vector3.Distance(owner.transform.position, target.transform.position);

        //if (index < GameManager.instance.GetPentagrams())
        //{
        //    navMeshAgent.speed += 0.2f;
        //    index++;
        //}
         
        if (distanceToTarget <= 2.5f)
        {            
            int valor = Random.Range(0, 3);
            if (valor == 0)
            {
                animator.SetBool("Attack", true);
                //AudioManager.instance.PlayAudio(AttackClip, "AttackSound");
                if (currentTime >= 3)
                {
                    AudioManager.instance.PlayAudio(AttackClip, "AttackSound");
                    currentTime = 0;
                }
                
            }
            else if (valor == 1)
            {
                animator.SetBool("Attack2", true);
                if (currentTime >= 3)
                {
                    AudioManager.instance.PlayAudio(AttackClip2, "AttackSound");
                    currentTime = 0;
                }
            }
            else
            {
                animator.SetBool("Attack3", true);
                if (currentTime >= 3)
                {
                    AudioManager.instance.PlayAudio(AttackClip3, "AttackSound");
                    currentTime = 0;
                }
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("Attack3", false);
        } 
        
        return nextState;
    }
}
