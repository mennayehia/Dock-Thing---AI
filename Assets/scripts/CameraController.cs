using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject mazeObject;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 20, -20);
        transform.LookAt(mazeObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(mazeObject.transform.position.x, transform.position.y, mazeObject.transform.position.z - 20);

    }
}
