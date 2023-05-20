using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ourFlockingManager : MonoBehaviour
{

    public GameObject ourBoid;
    
    public Vector3 boidLimits;
    public int boidCount;
    public GameObject[] ourBoidsArr;

    [Range(1.0f , 30f)]
    public float MaxBoidSpeed;

    public static ourFlockingManager ourFlockInstance;
    // Start is called before the first frame update
    void Start()
    {
        if(ourFlockInstance == null)
        {
            ourFlockInstance = this;
        }

        ourBoidsArr = new GameObject[boidCount];
        for (int i = 0; i < boidCount; i++)
        {
            ourBoidsArr[i] = GameObject.Instantiate(ourBoid, new Vector3(UnityEngine.Random.Range(-boidLimits.x, boidLimits.x) 
                , UnityEngine.Random.Range(-boidLimits.y , boidLimits.y)
                ,UnityEngine.Random.Range(-boidLimits.z , boidLimits.z))
                , Quaternion.identity
                , this.transform); 
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
