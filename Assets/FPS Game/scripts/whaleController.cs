using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whaleController : MonoBehaviour
{
    enum FishState { Patrol, Chase, Attack };
    public Transform[] waypoints;
    FishState currentState;
    private int wayPointsCounter;
    Animator animator;
    private bool IsAttack1 ;
    private bool IsAttack2 ;


    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    private Rigidbody fishRB;

    void Start()
    {
        fishRB = GetComponent<Rigidbody>();
        currentState = FishState.Patrol;
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        ChangeState(currentState);
        //Debug.Log(Vector3.SqrMagnitude(player.transform.position - this.transform.position));
        
        
    }

    private void ChangeState(FishState currentState)
    {
        switch (currentState)
        {
            case FishState.Patrol: Debug.Log("PATROL"); Patrol(); break;
            case FishState.Chase: Debug.Log("CHASE"); Chase(); break;
            case FishState.Attack: Debug.Log("ATTACK"); Attack(); break;
        }
    }

    public void Seek(Vector3 target)
    {
        var direction = (target - this.transform.position).normalized;
        transform.LookAt(transform.position + direction);
        fishRB.velocity = direction * speed;
    }

    private void Patrol()
    {
        Seek(waypoints[wayPointsCounter].transform.position);
        if (Vector3.SqrMagnitude(waypoints[wayPointsCounter].transform.position - this.transform.position) < 0.1f)
        {
            wayPointsCounter++;
            if (wayPointsCounter >= waypoints.Length)
            {
                wayPointsCounter = 0;
            }
        

        }


        if (Vector3.SqrMagnitude(player.transform.position - this.transform.position) < 300 && Vector3.SqrMagnitude(player.transform.position - this.transform.position) >200 )
        {
            Debug.Log("CHASE");
            currentState = FishState.Chase;
        }



    }

    private void Chase()
    {
        if (Vector3.SqrMagnitude(player.transform.position - this.transform.position) < 300f)
        {
            Seek(player.transform.position);
            //animator.Play("Attack1");
            IsAttack1 = true;
            animator.SetBool("IsAttack1", IsAttack1);
        }
        else
        {
            IsAttack1 = false;
            animator.SetBool("IsAttack1", IsAttack1);
        }

        if (Vector3.SqrMagnitude(player.transform.position - this.transform.position) < 200f)
        {
            //Debug.Log("Attack");
            currentState = FishState.Attack;
        }

        if (Vector3.SqrMagnitude(player.transform.position - this.transform.position) > 300f)
        {
            //Debug.Log("PATROL");
            currentState = FishState.Patrol;
        }

    }

    private void Attack()
    {
        if (Vector3.SqrMagnitude(player.transform.position - this.transform.position) < 200f)
        {
            Seek(player.transform.position);
            // animator.Play("Attack2");
            IsAttack2 = true;      
            animator.SetBool("IsAttack2", IsAttack2);
        }
        else
        {
            IsAttack2 = false;
            animator.SetBool("IsAttack2", IsAttack2);

        }

        if (Vector3.SqrMagnitude(player.transform.position - this.transform.position) > 200f && Vector3.SqrMagnitude(player.transform.position - this.transform.position) < 300)
        {
           // Debug.Log("chase");
            currentState = FishState.Chase;
        }

        if (Vector3.SqrMagnitude(player.transform.position - this.transform.position) > 300f)
        {
          // Debug.Log("PATROL");
            currentState = FishState.Patrol;
        }
    }
}
