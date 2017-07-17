using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour {

    public Transform wayPoint1;
    public Transform wayPoint2;

    private NavMeshController navMeshController;
    private StateMachine stateMachine;
    private int direction = 1;
    

	// Use this for initialization
	void Awake ()
    {
        stateMachine = GetComponent<StateMachine>();
        navMeshController = GetComponent<NavMeshController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (navMeshController.IsReached())
        {
            direction *= -1;
        }

        if(direction > 0)
        {
            navMeshController.NewNavMeshAgentPoint(wayPoint1.position);
        }
        if (direction < 1)
        {
            navMeshController.NewNavMeshAgentPoint(wayPoint2.position);
        }

    }

    void OnEnable ()
    {
        navMeshController.NewNavMeshAgentPoint(wayPoint1.position);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //gameObject.GetComponent<SphereCollider>().enabled = false;
            stateMachine.InitState(stateMachine.pursuitState);
        }
    }
}
