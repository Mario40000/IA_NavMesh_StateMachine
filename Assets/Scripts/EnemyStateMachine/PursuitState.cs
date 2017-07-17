using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitState : MonoBehaviour {

    private NavMeshController navMeshController;
    private StateMachine stateMachine;
    private GameObject player;


    // Use this for initialization
    void Awake()
    {
        navMeshController = GetComponent<NavMeshController>();
        stateMachine = GetComponent<StateMachine>();

    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshController.followTarget = player.GetComponent<Transform>();
        navMeshController.NewNavMeshAgentPoint(navMeshController.followTarget.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            navMeshController.followTarget = player.GetComponent<Transform>();
            navMeshController.NewNavMeshAgentPoint(navMeshController.followTarget.position);
        }
        
        //Cuando lleguemos al punto cambiamos a estado seguir
        if (player == null)
        {
            //gameObject.GetComponent<SphereCollider>().enabled = true;
            stateMachine.InitState(stateMachine.patrolState);
        }


    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            StaticData.playerDead = true;
            StaticData.lives--;
            Destroy(other.gameObject);

        }
    }


}
