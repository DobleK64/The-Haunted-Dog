using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CruzAction (A)", menuName = "ScriptableObject/Action/CruzAction")]
public class CruzAction : Action
{
    public override bool Check(GameObject owner)
    {
        GameObject target = owner.GetComponent<TargetReference>().target;

        

        return owner.GetComponent<PerroMostruo>().cruz;  // El target no tiene el tag "Cruz"
    }

    public override void DrawGizmos(GameObject owner)
    {
        // Aquí puedes agregar código para dibujar los Gizmos en el editor si lo necesitas
    }
}

