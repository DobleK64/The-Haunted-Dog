using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "SafeAction (A)", menuName = "ScriptableObject/Action/SafeAction")]
public class SafeAction : Action
{   
    public override bool Check(GameObject owner)
    {
        GameObject target = owner.GetComponent<TargetReference>().target;
        Hit hit = target.GetComponent<Hit>();
        List<GameObject> targetViewList = hit.viewList;
        
        foreach (GameObject objecthit in targetViewList)
        {
            if (owner == objecthit)
            {
                return true;
            }
        }
        return false;       
    }
   
    public override void DrawGizmos(GameObject owner)
    {
        
    }

}
