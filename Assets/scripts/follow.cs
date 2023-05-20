using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform target;
    public float stoppingDistance;
    public float fleeingDistance;
    public float speed;

    private Vector3 direction;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    //public void seek(Transform target)
    //{
    //    direction = target.position - this.transform.position;
    //    rb.velocity = direction * speed;
    //    this.transform.LookAt(target.position);

    //}

    public void flee(Transform target)
    {
        direction =(target.position - this.transform.position)*-1;
        rb.velocity = direction * speed;
        this.transform.LookAt((target.position)*-1);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.SqrMagnitude(this.transform.position - target.transform.position) < fleeingDistance)
        {
            
            flee(target.transform);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
