using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    public State initialState;
    private State currentState;

    private void Start()
    {
        currentState = initialState;
    }

    private void Update()
    {
        State nextState = currentState.Run(gameObject);
        if (nextState)
        {
            currentState = nextState;
        }
    }
    // llamar el OnDrawGizmos
    private void OnDrawGizmos()
    {
        if (currentState)
            currentState.DrawAllACtionsGizmo(gameObject);
        else if (initialState)
            initialState.DrawAllACtionsGizmo(gameObject);
    }
}