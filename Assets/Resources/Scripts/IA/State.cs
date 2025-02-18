using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ActionParameters
{
    [Tooltip("Action that is gonna be executed")]
    public Action action;
    [Tooltip("Indicate if the action´s check must be true or false")]
    public bool actionValue;
}

[System.Serializable]
public struct StateParameters
{
    [Tooltip("ActionParameters array")]
    public ActionParameters[] actionParameters;
    [Tooltip("If the action´s check equals actionValue, nextState is pushed")]
    public State nextState;
    [Tooltip("Se cumplen todas las acciones o solo se tiene que cumplir una")]
    public bool and;

}
public abstract class State : ScriptableObject
{
    public StateParameters[] stateParameters;
    //public State[] nextStates;
    //public Action[] actions;

    protected State ChecksActions(GameObject owner)//devolver true si alguna de sus acciones se cumple, o false si es al contrairio
    {
        bool todasLasAccionesSeHanCumplido = true;
        for (int i = 0; i < stateParameters.Length; ++i) //recorre los parametros
        {
            for (int j = 0; j < stateParameters[i].actionParameters.Length; j++)    //recorre las acciones de los parametros
            {
                ActionParameters actionParameter = stateParameters[i].actionParameters[j];
                if (actionParameter.action.Check(owner) == actionParameter.actionValue)    //Comprueba las acciones con los check
                {
                    if (!stateParameters[i].and)      //si solo se tiene que cumplir una 
                    {
                        //devolvemos directamente el siguiente 
                        return stateParameters[i].nextState;
                    }
                }
                else if (stateParameters[i].and)
                {
                    todasLasAccionesSeHanCumplido = false;
                    break;     //salimos del bucle porque una accion no se ha cumplido y estamos en and
                }
            }
            // si llegamos hasta aqui, significa que el diseñador ha marcado que todas las acciones tienen que cumplirse y, ademas, se han cumplido.
            // Tenemos que comprobar si de verdad se han cumplido todas
            if (stateParameters[i].and && todasLasAccionesSeHanCumplido)
            {
                return stateParameters[i].nextState;
            }
        }
        return null; // ninguna accion se cumple
    }
    public abstract State Run(GameObject owner);

    public void DrawAllACtionsGizmo(GameObject owner)
    {
        foreach (StateParameters parameter in stateParameters)
        {
            foreach (ActionParameters aP in parameter.actionParameters)
            {
                aP.action.DrawGizmos(owner);
            }
        }
    }
}