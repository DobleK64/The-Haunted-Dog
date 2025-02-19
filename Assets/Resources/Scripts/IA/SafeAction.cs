using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
[CreateAssetMenu(fileName = "SafeAction (A)", menuName = "ScriptableObject/Action/SafeAction")]
public class SafeAction : Action
{
    bool safe;
    public override bool Check(GameObject owner)
    {  
        return safe;
        owner.GetComponent<SafeAction>().safe = safe;
    }
    
    //public void Safe(bool safeA)
    //{
    //    safe = safeA;
    //}
    public override void DrawGizmos(GameObject owner)
    {
        
    }

}
