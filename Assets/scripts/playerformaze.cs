using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerformaze : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    //  private int targetCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();


        agent.SetDestination(target.transform.position);

        // targetCounter = random


    }

}