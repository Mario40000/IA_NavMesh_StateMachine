﻿using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement: MonoBehaviour
{

    NavMeshAgent agent;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                agent.SetDestination(hit.point);
            }
        }
    }


}
