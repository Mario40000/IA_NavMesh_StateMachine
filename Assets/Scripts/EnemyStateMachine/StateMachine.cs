using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    public MonoBehaviour pursuitState;
    public MonoBehaviour patrolState;
    public MonoBehaviour inicialState;

    private MonoBehaviour currentState;

    // Use this for initialization
    void Start()
    {
        InitState(inicialState);
    }

    //Iniciamos un nuevo estado
    public void InitState(MonoBehaviour newState)
    {
        if (currentState != null) currentState.enabled = false;
        currentState = newState;
        currentState.enabled = true;
    }
}
