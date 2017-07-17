using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour {

    [HideInInspector]
    public Transform followTarget;

    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Actualizamos el punto de destino de nuestro agente
    public void NewNavMeshAgentPoint(Vector3 destinationPoint)
    {
        agent.destination = destinationPoint;
        agent.Resume();
    }

    //Comprobamos si hemos llegado al punto definido
    public bool IsReached()
    {
        return agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending;
    }
}
