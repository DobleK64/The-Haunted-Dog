using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

[CreateAssetMenu(fileName = "SeeAction (A)", menuName = "ScriptableObject/Action/SeeAction")]

public class SeeAction : Action
{
    public float radius, radius2;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    [Range(0, 360)]
    public float angle;
    

    //public AudioClip HelloClip;
    private float currentTime = 0;
    private float maxTime = 2;
    private int valor = 1; 
    public override bool Check(GameObject owner)
    {
        Collider[] rangeChecks = Physics.OverlapSphere(owner.transform.position, radius, targetMask);
        //RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position, radius2, Vector3.up);
        currentTime += Time.deltaTime;
        Animator animator = owner.GetComponent<Animator>();

        if (rangeChecks.Length != 0)
        {
            GameObject target = owner.GetComponent<TargetReference>().target;
            //Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.transform.position - owner.transform.position).normalized;

            if (Vector3.Angle(owner.transform.forward, directionToTarget) < angle / 2)    //para que se calcule a partir del centro
            {
                float distanceToTarget = Vector3.Distance(owner.transform.position, target.transform.position);

                if (!Physics.Raycast(owner.transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    if (distanceToTarget < 1)
                    {
                        animator.SetBool("Attack3", true);
                    }
                    //foreach (RaycastHit hit in hits)
                    //{
                    //    if (hit.collider.gameObject == target)
                    //    {

                    //        if (currentTime > maxTime)
                    //        {
                    //            animator.SetBool("Attack3", true);
                    //            currentTime = 0;
                    //        }
                    //        return true;
                    //    }
                    //}
                    //return false;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        else
            return false;
    }
public override void DrawGizmos(GameObject owner)
    {
       
    }
}