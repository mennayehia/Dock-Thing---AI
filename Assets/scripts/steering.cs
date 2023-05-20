using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steering : MonoBehaviour
{
    public Transform target;
    public float stoppingDistance;
    public float speed;

    private Vector3 direction;
    private Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void seek(Vector3 target)
    {
        direction = (target - this .transform.position).normalized;
        rb.velocity = direction * speed;
        //this.transform.LookAt(target);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (Vector3.SqrMagnitude(this.transform.position - hit.point) > stoppingDistance)
                {
                    seek(hit.point);
                   // seek(target.transform);
                }
                else
                {
                    rb.velocity = Vector3.zero;
                }
            }
        }
        
    }
}
