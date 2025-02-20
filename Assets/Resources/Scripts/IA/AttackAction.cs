using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackAction (A)", menuName = "ScriptableObject/Action/AttackAction")]
public class AttackAction : Action
{
    public float radius = 1f;
    private float currentTime = 0;
    private float maxTime = 4;
    public AudioClip AClip;
    public override bool Check(GameObject owner)
    {
        RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position, radius, Vector3.up);
        GameObject target = owner.GetComponent<TargetReference>().target;
        Animator animator = target.GetComponent<Animator>();
        currentTime += Time.deltaTime;
        //foreach (RaycastHit hit in hits)
        //{
        //    if (hit.collider.gameObject == target)
        //    {
        //        if (currentTime > maxTime)
        //        {
        //            animator.SetBool("Attack", true);
        //            //AudioManager.instance.PlayAudio(AClip, "HelloSound");
        //            currentTime = 0;
        //        }
        //        else
        //        {
        //            animator.SetBool("Attack", false);
        //        }
        //        return true;
        //    }
        //}
        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(owner.transform.position, radius);  //la esfera para escuchar
    }
}
