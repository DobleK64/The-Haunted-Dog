using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Action : ScriptableObject
{
    // la accion no se puede implementar 
    public abstract bool Check(GameObject owner);   //ejecutar la accion

    //metodo abstracto de dibujar gizmo
    public abstract void DrawGizmos(GameObject owner);
}
