using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CruzAction (A)", menuName = "ScriptableObject/Action/CruzAction")]
public class CruzAction : Action
{
    public override bool Check(GameObject owner)
    {
        GameObject target = owner.GetComponent<TargetReference>().target;

        // Verificar si el tag del target es "Cruz"
        //if (target.CompareTag("Cruz"))
        //{
        //    return true;  // El target tiene el tag "Cruz"
        //}

        return false;  // El target no tiene el tag "Cruz"
    }

    public override void DrawGizmos(GameObject owner)
    {
        // Aqu� puedes agregar c�digo para dibujar los Gizmos en el editor si lo necesitas
    }
}

