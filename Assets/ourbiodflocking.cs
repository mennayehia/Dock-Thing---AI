using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ourbiodflocking : MonoBehaviour
{
    private GameObject[] boidsArr;
    private Rigidbody boidRB;
    public float seprationSpeed;
    [SerializeField] private float septDist;

    public float speedFunc;
    void Start()
    {
        boidsArr = ourFlockingManager.ourFlockInstance.ourBoidsArr;
        boidRB = GetComponent<Rigidbody>();

    }
    void Update()
    {
        boidRB.velocity = (Alignment() + Cohesion() + Separation() )*speedFunc;
    }

    public Vector3 Truncate(Vector3 v)
    {
        var speed = ourFlockingManager.ourFlockInstance.MaxBoidSpeed;
        if (v.magnitude > speed)
        {
            v = v.normalized * speed;
        }
        return v;
    }

    public Vector3 Alignment()
    {
        Vector3 AlignmentMove = Vector3.zero;
        foreach (var boid in boidsArr)
        {
            if (gameObject != boid.gameObject)
            {
                AlignmentMove += boid.transform.forward ;
            }
        }
        AlignmentMove /= (boidsArr.Length - 1);
        return AlignmentMove;
    }

    public Vector3 Cohesion()
    {
        Vector3 CohesionMove = Vector3.zero;
        foreach (var boid in boidsArr)
        {
            if (gameObject != boid.gameObject)
            {
                CohesionMove += boid.transform.position;
            }
        }
        CohesionMove /= (boidsArr.Length - 1);
        CohesionMove -= this.transform.position;
        return CohesionMove;
    }

    public Vector3 Separation()
    {
        Vector3 SeparationMove = Vector3.zero;
        int nAvoid = 0;
        foreach (var boid in boidsArr)
        {
            if (Vector3.Distance(transform.position, boid.transform.position) < septDist)
            {
                nAvoid++;
                SeparationMove += (transform.position - boid.transform.position).normalized * seprationSpeed;
            }
        }

        if (nAvoid > 0)
        {
            SeparationMove /= nAvoid;
        }

        return SeparationMove;
    }

}
