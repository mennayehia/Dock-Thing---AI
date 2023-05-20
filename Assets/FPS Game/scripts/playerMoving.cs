using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMoving : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] target;
    private int targetCounter = 0;
    public float distance = 1;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //agent.SetDestination(target.transform.position);

        targetCounter = UnityEngine.Random.Range(0 , target.Length);

        agent.SetDestination(target[targetCounter].transform.position);
        agent.transform.LookAt(target[targetCounter]);
    }

    void moveToTheNextTarget()
    {
        var counter = UnityEngine.Random.Range(0 , target.Length);
        if(counter == targetCounter )
        {
            targetCounter = UnityEngine.Random.Range(0 , target.Length);
        }
        targetCounter = counter;
        agent.SetDestination(target[targetCounter].transform.position);
    }

    private void Update()
    {
        if (Vector3.SqrMagnitude(target[targetCounter].transform.position - this.transform.position) < distance)
        {
            print("arrived");
            moveToTheNextTarget();
        }
    }
}
